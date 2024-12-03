namespace VulkanGraphicsEngine.Source
{
    public class Program
    {
        public static void Main(String[] args)
        {
            try
            {
                Engine engine = new Engine(640, 480, "Vulkan Graphics Engine");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"[Error] {exception.Message}\n" +
                                  $"{exception.StackTrace}");
            }
        }
    }
}
