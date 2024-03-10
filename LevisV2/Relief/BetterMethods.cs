namespace LevisV2.Relief
{
    public abstract class BetterMethods
    {
        /// <summary>
        /// Print a message
        /// </summary>
        /// <param name="message">Message to print</param>
        public static void print(object message)
        {
            Console.WriteLine(message);
        }
        /// <summary>
        /// Open character in text one-by-one
        /// </summary>
        /// <param name="message">Message to print</param>
        public static void CoolText(string message)
        {
            int index = 0;
            while (index < message.Length)
            {
                Console.Write(message[index]);
                Thread.Sleep(90);
                index++;
            }
        }
        /// <summary>
        /// Waiting for some seconds
        /// </summary>
        /// <param name="seconds">Seconds to wait</param>
        public static void WaitForSeconds(int seconds)
        {
            Thread.Sleep(seconds * 1000);
        }
    }
}
