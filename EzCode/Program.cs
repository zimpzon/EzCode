namespace EzCode
{
    class MyOptions
    {
        public string? DisplayName { get; set; }
        public bool DoTheThing { get; set; }
    }

    class MyService
    {
        Action<MyOptions> _optionsAction = null;
        MyOptions _options = new MyOptions();

        public void Configure(Action<MyOptions> options)
        {
            _optionsAction = options;
        }

        public void Run()
        {
            _optionsAction(_options);

            Console.WriteLine($"{_options.DisplayName} = {_options.DoTheThing}");
        }
    }

    internal class Program
    {
        static void C(MyOptions options)
        {
            options.DisplayName = "hi options!";
            options.DoTheThing = true;
        }

        static async Task Main(string[] args)
        {
            var myService = new MyService();

            myService.Configure(C);

            myService.Run();
        }
    }
}
