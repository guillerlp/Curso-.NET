namespace Paint{

    public class Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X {get; init;}
        public int Y {get; init;}
    }

    public class Color
    {
        public int R{get;init;}
        public int G{get;init;}
        public int B{get;init;}

        public Color(int r, int g, int b)
        {
            R = r;
            G = g;
            B = b;
        }
    }

    public abstract class Shape
    {
        protected Shape(Point start, Point end, Color color){
            Start = start;
            End = end;
            Color = color;
        }

        public Point Start {get;init;}
        public Point End {get;init;}
        public Color Color {get;init;}
    }

    public class Rectangle : Shape
    {
        public Rectangle(Point start, Point end, Color color) : base(start, end, color)
        {
        }
    }

    public class Circle : Shape
    {
        public Circle(Point start, Point end, Color color) : base(start, end, color)
        {
        }
    }

    public readonly record struct DtoShape(Point Start, Point End, string ColorName){}
    public readonly record struct DtoShapeColor(Point Start, Point End, Color Color){}

    public interface IToolBar
    {
        Shape? GetShape(string shapeName, DtoShape dtoShape);
    }

    public class ToolBar : IToolBar
    {
        public Dictionary<string, Color> Colors = new Dictionary<string, Color>();
        public Dictionary<string, Func<DtoShapeColor, Shape>> Shapes = new Dictionary<string, Func<DtoShapeColor, Shape>>();

        public void RegisterColors(string colorName, Color color)
        {
            Colors.Add(colorName, color);
        }

        public Color GetColor(string colorName)
        {
            return Colors[colorName];
        }

        public void RegisterShape(string shapeName, Func<DtoShapeColor, Shape> Ctor)
        {
            Shapes.Add(shapeName, Ctor);
        }

        public Shape? GetShape(string shapeName, DtoShape dtoShape)
        {
            var color = Colors[dtoShape.ColorName];
            var dtoShapeColor = new DtoShapeColor(dtoShape.Start, dtoShape.End, color); 
            var ctor = Shapes[shapeName];

            return ctor(dtoShapeColor);
        }
    }

    public interface ICanvas
    {
        void Add(Shape shape);
    }

    public class Canvas : ICanvas
    {
        private List<Shape> shapes = new List<Shape>();

        public void Add(Shape shape)
        {
            shapes.Add(shape);
        }
    }

    public abstract class CommandBase
    {
        public abstract void Execute();
    }

    public class AddCommand : CommandBase
    {
        private ICanvas _receiver;
        private Shape _shape;

        public AddCommand(ICanvas receiver, Shape shape){
            _receiver = receiver;
            _shape = shape;
        }

        public override void Execute()
        {
            _receiver.Add(_shape);
        }
    }

    public static class App
    {
        public static IToolBar toolBar = CreateToolbar();
        public static ICanvas canvas = CreateCanvas();

        private static IToolBar CreateToolbar()
        {
            var toolbar = new ToolBar();

            toolbar.RegisterColors("black", new Color(0,0,0));
            toolbar.RegisterColors("white", new Color(255,255,255));

            toolbar.RegisterShape("circle", dto => new Circle(dto.Start, dto.End, dto.Color));
            toolbar.RegisterShape("rectangle", dto => new Rectangle(dto.Start, dto.End, dto.Color));

            return toolbar;
        }

        private static ICanvas CreateCanvas()
        {
            return new Canvas();
        }

        public static void Add (string shapeName, DtoShape dtoShape){
            var shape = toolBar.GetShape(shapeName, dtoShape);

            if (shape != null)
            {
                CommandBase addCommand = new AddCommand(canvas, shape);
                addCommand.Execute();
            }
        }
    }
}


// var canvas = App.CreateCanvas();
// var toolbar = App.CreateToolbar();
// var dto = new DtoShape(new Point(0,0), new Point(360,360), "black");
// var shape = toolbar.GetShape("circle", dto);
// if(shape != null){
//     canvas.Add(shape);
// }

// var dto = new DtoShape(new Point(0,0), new Point(0,0), "black");
// App.run("add", "circle", dto)
 