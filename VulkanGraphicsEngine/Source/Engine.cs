using Silk.NET.Windowing;
using Silk.NET.Maths;
using Silk.NET.Input;

namespace VulkanGraphicsEngine.Source
{
    public class Engine
    {
        private static IWindow? _window;

        public Engine(int width, int height, string title)
        {
            WindowOptions options = WindowOptions.DefaultVulkan with
            {
                Size = new Vector2D<int>(width, height),
                Title = title
            };

            _window = Window.Create(options);
            _window.Initialize();

            if (_window.VkSurface == null)
            {
                throw new Exception("Current platform doesn't support Vulkan API.");
            }

            _window.Load += OnLoad;
            _window.Update += OnUpdate;
            _window.Render += OnRender;

            _window.Run();
        }

        private static void OnLoad()
        {
            IInputContext input = _window!.CreateInput();
            for (int i = 0; i < input.Keyboards.Count; i++)
                input.Keyboards[i].KeyDown += KeyDown;
        }

        private static void OnUpdate(double deltaTime)
        {
            Console.WriteLine("Update!");
        }

        private static void OnRender(double deltaTime)
        {
            Console.WriteLine("Render!");
        }

        private static void KeyDown(IKeyboard keyboard, Key key, int keyCode)
        {
            if (key == Key.Escape)
                _window!.Close();
        }

        private static void Dispose()
        {
            _window?.Dispose();
        }
    }
}