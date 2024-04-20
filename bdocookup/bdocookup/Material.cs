using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace bdocookup
{

    public class MaterialMap
    {
        public Material Material;
        public int No;
    }



    //Material can both be a raw material or a recipe depending on depth
    public  class Material
    {



        public string ID;
        
        public ObservableCollection<MaterialMap> Materials;

        public int degree = 0;


        public Material()
        {
           Materials = new System.Collections.ObjectModel.ObservableCollection<MaterialMap>();
        }


        //seeks all materials of oth depth recur.
        public ObservableCollection<MaterialMap> GetAllRawResources()
        {
            ObservableCollection<MaterialMap> mylist = new ObservableCollection<MaterialMap>();

            if (Materials.Count == 0)
            {

                MaterialMap newRawMap = new MaterialMap() { No = 1, Material = (Material)this };
                mylist.Add(newRawMap);
            }
            else
            {
                foreach (MaterialMap m in Materials)
                {
                    var list = m.Material.GetAllRawResources();
                    for (int i = 0; i < list.Count; i++)
                    {
                        list[i].No *= m.No;
                        mylist.Add(list[i]);
                    }

                }
            }





            //crunch
            ObservableCollection<MaterialMap> crunchedList = new ObservableCollection<MaterialMap>();

            for (int i = 0; i < mylist.Count; i++)
            {
                bool flag = false;
                //check if curnched list has it
                for(  int c = 0;  c < crunchedList.Count; c++)
                {
                    if(crunchedList[c].Material.ID == mylist[i].Material.ID)
                    {
                        flag = true;
                        crunchedList[c].No += mylist[i].No;
                    }
                    else
                    {
                        
                    }
                }

                if(!flag)
                {
                    crunchedList.Add(new MaterialMap() { Material = mylist[i].Material, No = mylist[i].No });
                }
            }

            return crunchedList;
        }



        //calculates depth 
        public int CalculateDegree()
        {

            int mydegree = 0;
            if (Materials.Count == 0)
            {

            }
            else
            {
                mydegree = 1;
                foreach (MaterialMap m in Materials)
                {
                    mydegree += m.Material.CalculateDegree();
                    
                }
            }
            degree = mydegree;
            return mydegree;
        }


        //seeks all materials of nth depth recursevely
        public ObservableCollection<MaterialMap> GetMaterialsOfDegree( int degree)
        {
            ObservableCollection<MaterialMap> mylist = new ObservableCollection<MaterialMap>();

            if (this.degree == degree)
            {

                MaterialMap newRawMap = new MaterialMap() { No = 1, Material = (Material)this };
                mylist.Add(newRawMap);
            }
            else
            {
                foreach (MaterialMap m in Materials)
                {
                    var list = m.Material.GetMaterialsOfDegree(degree);
                    for (int i = 0; i < list.Count; i++)
                    {
                        list[i].No *= m.No;
                        mylist.Add(list[i]);
                    }

                }
            }





            //crunch
            ObservableCollection<MaterialMap> crunchedList = new ObservableCollection<MaterialMap>();

            for (int i = 0; i < mylist.Count; i++)
            {
                bool flag = false;
                //check if curnched list has it
                for (int c = 0; c < crunchedList.Count; c++)
                {
                    if (crunchedList[c].Material.ID == mylist[i].Material.ID)
                    {
                        flag = true;
                        crunchedList[c].No += mylist[i].No;
                    }
                    else
                    {

                    }
                }

                if (!flag)
                {
                    crunchedList.Add(new MaterialMap() { Material = mylist[i].Material, No = mylist[i].No });
                }
            }

            return crunchedList;
        }


    }
}
