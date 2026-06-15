using System.Linq;
using System.Collections.Generic;
using MonAmourKiosk.Models;

namespace MonAmourKiosk.Data;

public static class SeedData
{
    public static void Initialize(BistroContext context)
    {
        context.Database.EnsureCreated();

        if (context.Products.Any()) return;

        var products = new List<Product>
        {
            // Menu Café
            new() { Name = "Café Expresso", Category = "Café", Description = "Expresso intense au parfum complexe d'or brun.", Price = 2.50m, ImagePath = "Assets/Cafe/cafe_expresso.jpg", StockQuantity = 150 },
            new() { Name = "Café Allongé", Category = "Café", Description = "Expresso adouci à l'eau de source chaude.", Price = 2.70m, ImagePath = "Assets/Cafe/cafe_allonge.jpg", StockQuantity = 150 },
            new() { Name = "Café Crème", Category = "Café", Description = "Expresso velouté coiffé de sa fine crème de lait mousseuse.", Price = 3.80m, ImagePath = "Assets/Cafe/cafe_creme.jpg", StockQuantity = 120 },
            new() { Name = "Café Noisette", Category = "Café", Description = "Expresso traditionnel rehaussé d'une larme de lait chaud.", Price = 2.90m, ImagePath = "Assets/Cafe/cafe_noisette.jpg", StockQuantity = 100 },
            new() { Name = "Café Viennois", Category = "Café", Description = "Double expresso surmonté d'une crème fouettée onctueuse.", Price = 4.90m, ImagePath = "Assets/Cafe/cafe_viennois.jpg", StockQuantity = 80 },
            new() { Name = "Café au Lait", Category = "Café", Description = "Mélange réconfortant de café filtre et de lait chaud mousseux.", Price = 3.50m, ImagePath = "Assets/Cafe/cafe_au_lait.jpg", StockQuantity = 110 },
            new() { Name = "Cappuccino", Category = "Café", Description = "Équilibre somptueux entre expresso, lait chaud et nuage de cacao.", Price = 4.50m, ImagePath = "Assets/Cafe/cappuccino.jpg", StockQuantity = 90 },
            new() { Name = "Latte", Category = "Café", Description = "Grand volume de lait texturé lié à un expresso raffiné.", Price = 4.60m, ImagePath = "Assets/Cafe/latte.jpg", StockQuantity = 90 },
            new() { Name = "Moka", Category = "Café", Description = "Alliance parfaite d'un expresso, de chocolat chaud artisanal et de lait indonésien.", Price = 5.20m, ImagePath = "Assets/Cafe/moka.jpg", StockQuantity = 75 },
            new() { Name = "Chocolat Chaud", Category = "Café", Description = "Véritable chocolat noir fondu à l'ancienne, crémeux à souhait.", Price = 4.80m, ImagePath = "Assets/Cafe/chocolat_chaud.jpg", StockQuantity = 60 },

            // Menu Boulangerie
            new() { Name = "Croissant Beurre", Category = "Boulangerie", Description = "Pur beurre de Charentes-Poitou AOP, feuilletage croustillant.", Price = 1.80m, ImagePath = "Assets/Bakery/croissant_beurre.jpg", StockQuantity = 45 },
            new() { Name = "Pain au Chocolat", Category = "Boulangerie", Description = "Feuilletage doré garni de deux barres fondantes de chocolat noir.", Price = 1.90m, ImagePath = "Assets/Bakery/pain_au_chocolat.jpg", StockQuantity = 40 },
            new() { Name = "Pain aux Raisins", Category = "Boulangerie", Description = "Pâte briochée garnie de crème pâtissière fine et de raisins secs macérés.", Price = 2.20m, ImagePath = "Assets/Bakery/pain_aux_raisins.jpg", StockQuantity = 30 },
            new() { Name = "Pain Suisse", Category = "Boulangerie", Description = "Brioche feuilletée aux éclats de chocolat et crème pâtissière.", Price = 2.40m, ImagePath = "Assets/Bakery/pain_suisse.jpg", StockQuantity = 25 },
            new() { Name = "Brioche", Category = "Boulangerie", Description = "Pâte moelleuse tressée, riche en beurre frais et œufs bio.", Price = 2.10m, ImagePath = "Assets/Bakery/brioche.jpg", StockQuantity = 30 },
            new() { Name = "Baguette Tradition", Category = "Boulangerie", Description = "Mie alvéolée parfumée, croûte intensément croustillante.", Price = 1.30m, ImagePath = "Assets/Bakery/baguette_tradition.jpg", StockQuantity = 70 },
            new() { Name = "Madeleine", Category = "Boulangerie", Description = "Petite douceur moelleuse traditionnelle parfumée à la fleur d'oranger.", Price = 1.50m, ImagePath = "Assets/Bakery/madeleine.jpg", StockQuantity = 80 },
            new() { Name = "Chausson aux Pommes", Category = "Boulangerie", Description = "Feuilletage croustillant abritant une compotée de pommes douces.", Price = 2.30m, ImagePath = "Assets/Bakery/chausson_pommes.jpg", StockQuantity = 35 },

            // Menu Bistro
            new() { Name = "Croque Monsieur", Category = "Bistro", Description = "Jambon blanc supérieur, sauce béchamel maison et Comté AOP gratiné.", Price = 9.50m, ImagePath = "Assets/Bistro/croque_monsieur.jpg", StockQuantity = 20 },
            new() { Name = "Croque Madame", Category = "Bistro", Description = "Notre traditionnel croque monsieur couronné d'un œuf au plat bio.", Price = 10.50m, ImagePath = "Assets/Bistro/croque_madame.jpg", StockQuantity = 15 },
            new() { Name = "Quiche Lorraine", Category = "Bistro", Description = "Lardons paysans fumés au bois de hêtre et appareil à crème onctueuse.", Price = 8.50m, ImagePath = "Assets/Bistro/quiche_lorraine.jpg", StockQuantity = 25 },
            new() { Name = "Soupe à l'Oignon", Category = "Bistro", Description = "Bouillon de bœuf traditionnel aux oignons confits, croûtons et fromage fondu.", Price = 7.90m, ImagePath = "Assets/Bistro/soupe_oignon.jpg", StockQuantity = 18 },
            new() { Name = "Omelette aux Herbes", Category = "Bistro", Description = "Œufs frais battus minute, herbes aromatiques fraîches du potager.", Price = 8.20m, ImagePath = "Assets/Bistro/omelette_herbes.jpg", StockQuantity = 30 },
            new() { Name = "Salade Niçoise", Category = "Bistro", Description = "Thon germon, anchois, olives de Nice, œufs durs et crudités de saison.", Price = 12.40m, ImagePath = "Assets/Bistro/salade_nicoise.jpg", StockQuantity = 22 },
            new() { Name = "Steak Frites", Category = "Bistro", Description = "Pièce de bœuf charolais saisie à la perfection, frites fraîches maison.", Price = 16.90m, ImagePath = "Assets/Bistro/steak_frites.jpg", StockQuantity = 15 },
            new() { Name = "Coq au Vin", Category = "Bistro", Description = "Mijoté traditionnel de coq au vin rouge corsé, champignons de Paris et lardons.", Price = 18.50m, ImagePath = "Assets/Bistro/coq_au_vin.jpg", StockQuantity = 12 },
            new() { Name = "Bœuf Bourguignon", Category = "Bistro", Description = "Viande bovine fondante braisée au vin de Bourgogne, carottes et aromates.", Price = 19.20m, ImagePath = "Assets/Bistro/boeuf_bourguignon.jpg", StockQuantity = 10 },

            // Menu Desserts
            new() { Name = "Crème Brûlée", Category = "Desserts", Description = "Crème onctueuse à la vanille Bourbon de Madagascar, caramélisée minute.", Price = 6.50m, ImagePath = "Assets/Desserts/creme_brulee.jpg", StockQuantity = 25 },
            new() { Name = "Mille-Feuille", Category = "Desserts", Description = "Feuilletage inversé croustillant et crème diplomate vanillée.", Price = 5.80m, ImagePath = "Assets/Desserts/mille_feuille.jpg", StockQuantity = 15 },
            new() { Name = "Tarte Tatin", Category = "Desserts", Description = "Tarte de pommes caramélisées fondantes, servie avec sa crème fraîche.", Price = 6.80m, ImagePath = "Assets/Desserts/tarte_tatin.jpg", StockQuantity = 18 },
            new() { Name = "Macaron", Category = "Desserts", Description = "Assortiment de trois macarons gourmands aux ganaches de saison.", Price = 4.50m, ImagePath = "Assets/Desserts/macaron.jpg", StockQuantity = 50 },
            new() { Name = "Éclair au Chocolat", Category = "Desserts", Description = "Pâte à choux garnie d'une crème pâtissière intense au chocolat noir 70%.", Price = 4.20m, ImagePath = "Assets/Desserts/eclair_chocolat.jpg", StockQuantity = 20 },
            new() { Name = "Mousse au Chocolat", Category = "Desserts", Description = "Recette traditionnelle aérienne au chocolat pur beurre d'Équateur.", Price = 5.10m, ImagePath = "Assets/Desserts/mousse_chocolat.jpg", StockQuantity = 30 },
            new() { Name = "Profiteroles", Category = "Desserts", Description = "Trois choux garnis de glace vanille, nappés de chocolat chaud fluide.", Price = 7.50m, ImagePath = "Assets/Desserts/profiteroles.jpg", StockQuantity = 16 },
            new() { Name = "Île Flottante", Category = "Desserts", Description = "Blancs d'œufs pochés ultra-légers sur une crème anglaise safranée, caramel filé.", Price = 5.50m, ImagePath = "Assets/Desserts/ile_flottante.jpg", StockQuantity = 24 }
        };

        context.Products.AddRange(products);
        context.SaveChanges();

        // Liaisons d'Upselling d'Algorithme Intelligent (Café -> Douceurs)
        var cafeCreme = context.Products.First(p => p.Name == "Café Crème");
        var croissant = context.Products.First(p => p.Name == "Croissant Beurre");
        var painChoc = context.Products.First(p => p.Name == "Pain au Chocolat");
        var madeleine = context.Products.First(p => p.Name == "Madeleine");

        var cappuccino = context.Products.First(p => p.Name == "Cappuccino");
        var eclair = context.Products.First(p => p.Name == "Éclair au Chocolat");
        var brioche = context.Products.First(p => p.Name == "Brioche");
        var tatin = context.Products.First(p => p.Name == "Tarte Tatin");

        var chocolatChaud = context.Products.First(p => p.Name == "Chocolat Chaud");
        var macaron = context.Products.First(p => p.Name == "Macaron");
        var milleFeuille = context.Products.First(p => p.Name == "Mille-Feuille");

        context.Recommendations.AddRange(new List<Recommendation>
        {
            new() { CoffeeId = cafeCreme.Id, RecommendedProductId = croissant.Id },
            new() { CoffeeId = cafeCreme.Id, RecommendedProductId = painChoc.Id },
            new() { CoffeeId = cafeCreme.Id, RecommendedProductId = madeleine.Id },

            new() { CoffeeId = cappuccino.Id, RecommendedProductId = eclair.Id },
            new() { CoffeeId = cappuccino.Id, RecommendedProductId = brioche.Id },
            new() { CoffeeId = cappuccino.Id, RecommendedProductId = tatin.Id },

            new() { CoffeeId = chocolatChaud.Id, RecommendedProductId = macaron.Id },
            new() { CoffeeId = chocolatChaud.Id, RecommendedProductId = milleFeuille.Id }
        });

        context.SaveChanges();
    }
}