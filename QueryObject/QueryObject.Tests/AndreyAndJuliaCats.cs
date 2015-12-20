using Domain;

namespace QueryObject
{
    class AndreyAndJuliaCats
    {
        public Cat[] AllCats;
        public Person[] AllPersons;

        public Cat[] AndreyCats;
        public Cat[] JuliaCats ;
        public Cat Bonifacii;
        public Cat Sansa;
        public Cat Maikl;
        public Person Andrey;
        public Person Julia;


        public AndreyAndJuliaCats()
        {
            Bonifacii = new Cat {CuteFactor = 10, Id = 1, Name = "Bonifaciy", OwnerId = 1};
            Sansa = new Cat {CuteFactor = 5, Id = 2, Name = "Sansa", OwnerId = 2};
            Maikl = new Cat {CuteFactor = 5, Id = 3, Name = "Maikl", OwnerId = 3};
            AllCats = new[]
            {
                Bonifacii,
                Sansa,
                Maikl
            };

            AndreyCats = new[]
            {
                Bonifacii,
                Maikl
            };

            JuliaCats = new[]
            {
                Sansa
            };

            Andrey = new Person() {Age = 15, Gender = Gender.Male, Id = 1, Name = "Andrey"};
            Julia = new Person() {Age = 13, Gender = Gender.Female, Id = 2, Name = "Julia"};
            AllPersons = new[]
            {
                Andrey,
                Julia
            };
        }
    }
}