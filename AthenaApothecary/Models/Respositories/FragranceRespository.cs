namespace AthenaApothecary.Models.Respositories
{
    public class FragranceRepository
    {
        private static List<Fragrance> fragrances = new List<Fragrance>
        {
            new Fragrance { Id = 1, Title = "Tolu", Perfumer = "Ormonde Jayne", Gender = "Men/Women",
                Description = "Tolu is an exotic fragrance based on Peruvian tolu resin, from a precious variety of tree in South America. " +
                "Laced with frankincense and amber and a heady mix of floral and herbal top notes, Tolu takes the wearer on a sensual oriental journey.",
                Price = 199, FragranceNotes = "Juniper Berry, Orange Blossom and Clary Sage yield to a heart of Orchid, Moroccan Rose and Muguet. " +
                "The base features precious Tolu, Tonka Bean, Golden Frankincense and Amber."},
            new Fragrance { Id = 2, Title = "Aoud Cafe", Perfumer = "Mancera", Gender = "Men/Women",
                Description = "Aoud Café by Mancera is a Amber Vanilla fragrance for women and men. Aoud Café was launched in 2013. The nose behind this fragrance is Pierre Montale.",
                Price = 95, FragranceNotes = "Top notes are Black Currant, Bergamot and Peach; middle notes are Coffee, Amber and Floral Notes; base notes are Woody Notes, Sweet Notes and White Musk."},
            new Fragrance { Id = 3, Title = "Apollonia", Perfumer = "Xerjoff", Gender = "Men/Women",
                Description = "Apollonia by Xerjoff is a Floral fragrance for women and men. Apollonia was launched in 2019.",
                Price = 199, FragranceNotes = "Top note is White Flowers; middle note is Orris; base note is White Musk."},
            new Fragrance { Id = 4, Title = "Tasmeem", Perfumer = "Rasasi", Gender = "Men",
                Description = "Tasmeem Men by Rasasi is a Amber Spicy fragrance for men.",
                Price = 65, FragranceNotes = "Top notes are Cumin, Cardamom and Artemisia; middle notes are Rose and Orris Root; base notes are Vanilla, Tonka Bean, Sandalwood, Amber, Patchouli and Musk."},
            new Fragrance { Id = 5, Title = "La Yuqawam Jasmine Wisp", Perfumer = "Rasasi", Gender = "Women",
                Description = "La Yuqawam Jasmine Wisp by Rasasi is a Floral Fruity Gourmand fragrance for women. La Yuqawam Jasmine Wisp was launched in 2016. ",
                Price = 75, FragranceNotes = "La Yuqawam Jasmine Wisp by Rasasi is a Floral Fruity Gourmand fragrance for women. La Yuqawam Jasmine Wisp was launched in 2016. "}
        };

        public static List<Fragrance> GetFragrances()
        {
            return fragrances;
        }

        public static bool FragranceExists(int id)
        {
            return fragrances.Any(x => x.Id == id);
        }

        public static Fragrance? GetFragranceById(int id)
        {
            return fragrances.FirstOrDefault(x => x.Id == id);
        }

        public static Fragrance? GetFragranceByProperties(string? title, string? gender, double? price)
        {
            return fragrances.FirstOrDefault(x =>
                !string.IsNullOrWhiteSpace(title) &&
                !string.IsNullOrWhiteSpace(x.Title) &&
                x.Title.Equals(title, StringComparison.OrdinalIgnoreCase) &&
                !string.IsNullOrWhiteSpace(gender) &&
                !string.IsNullOrWhiteSpace(x.Gender) &&
                x.Gender.Equals(gender, StringComparison.OrdinalIgnoreCase) &&
                price.HasValue &&
                x.Price.HasValue &&
                price.Value == x.Price.Value
            );
        }

        public static void AddFragrance(Fragrance fragrance)
        {
            int maxId = fragrances.Max(x => x.Id);
            fragrance.Id = maxId + 1;
            fragrances.Add(fragrance);
        }

        public static void UpdateFragrance(Fragrance fragrance)
        {
            var fragranceToUpdate = fragrances.First(x => x.Id == fragrance.Id);
            fragranceToUpdate.Title = fragrance.Title;
            fragranceToUpdate.Perfumer = fragrance.Perfumer;
            fragranceToUpdate.Description = fragrance.Description;
            fragranceToUpdate.FragranceNotes = fragrance.FragranceNotes;
            fragranceToUpdate.Price = fragrance.Price;
        }

        public static void DeleteFragrance(int id)
        {
            var fragrance = GetFragranceById(id);
            if (fragrance != null)
            {
                fragrances.Remove(fragrance);
            }
        }
    }
}
