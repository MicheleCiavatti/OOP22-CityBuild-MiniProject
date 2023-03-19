namespace Model {

    ///This class is a translation of PlayerImpl in the main project
    public class Player {

        private readonly Dictionary<Resource, int> _resources;

        public Player() {
            _resources = new Dictionary<Resource, int>();
        }

        public static void Main() {
            Console.WriteLine("Hello");
        }
    }
}
