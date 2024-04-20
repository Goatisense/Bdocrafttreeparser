using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace bdocookup
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        //just demonstrates how it is used with "Simple Crone Meal" 

        public ItemList Recipes;
        public MainWindow()
        {
            InitializeComponent();


            Recipes = new ItemList();

            InitStuff();
            
        }

        public void InitStuff()
        {
            Material CronMeal = new Material();

            var main = Recipes.AddOrFind("Simple Cron Meal");

        

            Recipes.AddAndAddMaterial("Simple Cron Meal", new string[]{ "Valencia Meal", "Mediah Meal", "Knight Combat Rations" }, new int[]{ 1,1,1 } );



            Recipes.AddAndAddMaterial("Valencia Meal", new string[] { "Teff Sandwich", "King of Jungle Hamburg","Couscous", "Fig Pie", "Date Palm Wine" }, new int[] { 1,1,1,2,2 });

            Recipes.AddAndAddMaterial("Mediah Meal", new string[] { "Dark Pudding", "Oatmeal", "Grilled Sausage", "Lean Meat Salad", "Makgeolli" }, new int[] { 1, 1, 2, 1, 2 });

            Recipes.AddAndAddMaterial("Knight Combat Rations", new string[] { "Dark Pudding", "Ham Sandwich", "Meat Croquette", "Fruit Wine" }, new int[] { 1, 1, 1, 1 });

            Recipes.AddAndAddMaterial("Teff Sandwich", new string[] { "Teff Bread", "Grilled Scorpion", "Freekeh Snake Stew", "Red Sauce" }, new int[] { 1, 1, 1, 1 });

            Recipes.AddAndAddMaterial("King of Jungle Hamburg", new string[] { "Lion Meat", "Teff Bread", "Pickled Vegetables", "Nutmeg" }, new int[] { 4, 4, 2, 3 });

            Recipes.AddAndAddMaterial("Couscous", new string[] { "Freekeh Snake Stew", "Teff Flour Dough", "Nutmeg", "Veggie" }, new int[] { 1, 6, 3, 4 });


            Recipes.AddAndAddMaterial("Fig Pie", new string[] { "Fig", "Dough", "Sugar", "Oil" }, new int[] { 5, 3, 3, 2 });

            Recipes.AddAndAddMaterial("Date Palm Wine", new string[] { "Date Palm", "Essence of Liquor", "Sugar", "Leavening Agent" }, new int[] { 5, 2, 1, 4 });

            Recipes.AddAndAddMaterial("Dark Pudding", new string[] { "Oatmeal", "Pickled Vegetables", "Chicken Meat", "Sheep Blood" }, new int[] { 1, 1, 5, 7 });

            Recipes.AddAndAddMaterial("Grilled Sausage", new string[] { "Red Meat", "Onion", "Pepper", "Salt" }, new int[] { 6, 1, 2, 2 });

            Recipes.AddAndAddMaterial("Lean Meat Salad", new string[] { "Red Meat", "Vinegar", "Pepper", "Dressing" }, new int[] { 8, 2, 3, 4 });

            Recipes.AddAndAddMaterial("Makgeolli", new string[] { "Dough", "Essence of Liquor", "Mineral Water", "Leavening Agent" }, new int[] { 3, 1, 5, 2 });


            Recipes.AddAndAddMaterial("Ham Sandwich", new string[] { "Soft Bread", "Grilled Sausage", "Veggie", "Egg" }, new int[] { 2, 2, 5, 4 });

            Recipes.AddAndAddMaterial("Meat Croquette", new string[] { "Red Meat", "Flour", "Egg", "Cheese", "Oil" }, new int[] { 8, 5, 2, 2, 4 });

            Recipes.AddAndAddMaterial("Fruit Wine", new string[] { "Makgeolli", "Fruit", "Essence of Liquor", "Mineral Water" }, new int[] { 1, 5, 3, 2});

            Recipes.AddAndAddMaterial("Essence of Liquor", new string[] { "Flour", "Fruit", "Leavening Agent" }, new int[] { 1, 1, 1});

            Recipes.AddAndAddMaterial("Cheese", new string[] { "Milk" }, new int[] { 1 });

            Recipes.AddAndAddMaterial("Flour", new string[] { "Corn" }, new int[] { 1 });

            Recipes.AddAndAddMaterial("Soft Bread", new string[] { "Dough", "Leavening Agent", "Egg", "Milk" }, new int[] { 6, 2, 2, 3 });

            Recipes.AddAndAddMaterial("Dough", new string[] { "Flour", "Mineral Water" }, new int[] { 1,1 });

            Recipes.AddAndAddMaterial("Teff Bread", new string[] { "Teff Flour", "Mineral Water", "Salt", "Leavening Agent" }, new int[] { 5, 3, 2, 2 });

            Recipes.AddAndAddMaterial("Teff Flour", new string[] { "Teff" }, new int[] { 1 });


            Recipes.AddAndAddMaterial("Grilled Scorpion", new string[] { "Scorpion Meat", "Butter", "Nutmeg", "Hot Pepper" }, new int[] { 3, 2, 3, 3 });


            Recipes.AddAndAddMaterial("Freekeh Snake Stew", new string[] { "Mineral Water", "Freekeh", "Snake Meat", "Star Anise" }, new int[] { 5, 6, 3, 2 });


            Recipes.AddAndAddMaterial("Butter", new string[] { "Cream","Salt" }, new int[] { 1,1 });

            Recipes.AddAndAddMaterial("Cream", new string[] { "Milk", "Sugar" }, new int[] { 1, 1 });

            Recipes.AddAndAddMaterial("Teff Flour Dough", new string[] { "Teff Flour", "Mineral Water" }, new int[] { 1, 1 });



            Recipes.AddAndAddMaterial("Pickled Vegetables", new string[] { "Veggie", "Vinegar", "Leavening Agent", "Sugar" }, new int[] { 8, 4, 2, 2 });


            Recipes.AddAndAddMaterial("Vinegar", new string[] { "Corn", "Fruit", "Leavening Agent", "Sugar" }, new int[] { 1, 1, 1, 1 });

            Recipes.AddAndAddMaterial("Oatmeal", new string[] { "Flour", "Milk", "Onion", "Honey" }, new int[] { 9, 3, 3, 2 });

            Recipes.AddAndAddMaterial("Dressing", new string[] { "Egg", "Olive Oil", "Mineral Water", "Salt" }, new int[] { 1, 1, 1, 2 });


            //populates "degrees", or the debth in the crafting tree of simple crone meal
            var degree = main.CalculateDegree();

            //leaves essentialy 0th degrees, you can use the other function instead
            var res = main.GetAllRawResources();

            //gets nth depth materials
            var res2 = main.GetMaterialsOfDegree(1);


            //2ndlevel recipes


            //simple ugly UI display
            string empties = "";




            ////1st level
            //foreach (var r in res)
            //{
            //    empties += r.Material.ID + " " + r.No + "\n";
            //}
            //int a = 123;
            //resultings.Text = empties;


            //2nd level
            foreach (var r in res2)
            {
                empties += r.Material.ID + " " + r.No + "\n";
            }
            int a = 123;
            resultings.Text = empties;
        }

    }
}
