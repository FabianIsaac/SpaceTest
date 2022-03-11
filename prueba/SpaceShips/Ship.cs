namespace SpaceShips
{
	public class Ship
	{
        public int Id { get; set; }
		public string Name { get; set; }
		public string Model { get; set; }
		public string Type { get; set; }
		public int Armor { get; set; }
		public int Stamina { get; set; }
		public int Power { get; set; }
		public string Image { get; set; }
		public bool Passengers { get; set; }
		public int PassengersLimit { get; set; }
		public bool Cargo { get; set; }
		public int CargoLimit { get; set; }
	}
}
