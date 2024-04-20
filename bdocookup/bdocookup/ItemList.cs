using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace bdocookup
{
    public class ItemList
    {



        // Bookeeping object for global totals.

        public ObservableCollection<Material> Items;


        public ItemList()
        {
            Items = new ObservableCollection<Material>();

        }



        public void AddAndAddMaterial( String product,  string[] materials,  int[] amounts)
        {      
            var res = AddOrFind(product);

            for ( int i = 0;  i < materials.Length; i++)
            {
                res.Materials.Add(new MaterialMap() { Material = AddOrFind(materials[i]), No = amounts[i] });

            }
            
        }

        public Material AddOrFind( string ID)
        {
            bool flag = false;
            int index = 0;
            for (int i = 0; i < Items.Count; i++)
            {

                if (Items[i].ID == ID)
                {
                    flag = true;
                    index = i;
                }

            }

            if( !flag)
            {
                Items.Add(new Material { ID = ID });
                return Items.Last();
            }
            else { return Items[index]; }
        }

        public void AddItem(Material item)
        {
            bool flag = false;
            for ( int i  = 0; i < Items.Count; i++ )
            {
                
                if (Items[i].ID == item.ID)
                {
                    flag = true;
                }

            }

            if ( !flag ) { Items.Add(item); }
        }

        public ObservableCollection<Material> GetEmptyItems()
        {
            ObservableCollection <Material> empties
                = new ObservableCollection<Material>();

            for (int i = 0; i < Items.Count; i++)
            {

                if ( Items[i].Materials.Count <= 0)
                {
                    empties.Add((Material)Items[i]);
                }

            }

            return empties;
        }
    }
}
