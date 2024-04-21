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


        public class SimulateToken
        {
            public List<MaterialMap> quota;
            public bool possible = true;
        }
        public SimulateToken SimulateCraft(Storage store, Storage crafts)
        {
            List<MaterialMap> materials = new List<MaterialMap>();

            if( store.Use(this.ID,1) == true)
            {
                //no need to craft any

                SimulateToken token = new SimulateToken();
                token.quota = materials;
                token.possible = true;
                    

                return token;
            }
            else
            {
                bool possible = true;
                if( Materials.Count > 0){
                    for (int i = 0; i < Materials.Count; i++)
                    {
                        for (int j = 0; j < Materials[i].No; j++)
                        {
                            var token = Materials[i].Material.SimulateCraft(store, crafts);
                            if (!token.possible)
                                possible = false;
                            else
                            {
                                materials.AddRange(token.quota);
                            }
                                
 
                        }

                    }

                    if(possible)
                    {
                        crafts.Produce(this.ID, 1);
                        

                        SimulateToken token = new SimulateToken();


                        materials.Add( new MaterialMap() { Material = this, No = 1});
                        token.quota = materials;
                        token.possible = true;

                        return token;

                    }

                    else {
                        SimulateToken token = new SimulateToken();
                        token.quota = new List<MaterialMap>();
                        token.possible = false;

                        return token;
                    }
                }
                else
                {

                    //crafting not possible, end simulation

                    SimulateToken token = new SimulateToken();
                    token.quota = new List<MaterialMap>();
                    token.possible = false;

                    return token;


                }


            }


        }


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

        public ObservableCollection<MaterialMap> GetAllMaterials()
        {
            ObservableCollection<MaterialMap> mylist = new ObservableCollection<MaterialMap>();



            MaterialMap newRawMap = new MaterialMap() { No = 1, Material = (Material)this };
            mylist.Add(newRawMap);
            foreach (MaterialMap m in Materials)
            {
                var list = m.Material.GetAllMaterials();
                for (int i = 0; i < list.Count; i++)
                {
                    list[i].No *= m.No;
                    mylist.Add(list[i]);
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
