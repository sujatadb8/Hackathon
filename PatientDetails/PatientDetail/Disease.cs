using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientDetail;

namespace PatientDetail
{
    interface DiseaseOfPatient
    {
        void AddDisease(Disease des);
        void AddSymptoms(Symptom sympt );
       Symptom[] CheckDetail(string SymptomName);

    }
    class DiseaseDataBase : DiseaseOfPatient
    {
        private ArrayList _arrayList = new ArrayList();
        private int size;

        public DiseaseDataBase(int size)
        {
            this.size = size;
        }

        public void AddDisease(Disease des)
        {
            try
            {
                _arrayList.Add(des);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                
            }
          
        }

        public void AddSymptoms(Symptom sympt)
        {
            try
            {
                _arrayList.Add(sympt);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           
        }

        internal Symptom[] CheckDetail(string SymptomName)
        { 
                int count = 0;
                foreach (Symptom sympt in _arrayList)
                {
                    if (sympt != null && sympt.SymptomName.Contains(SymptomName))
                    {
                        count += 1;
                    }
                }
                Symptom[] symptoms = new Symptom[count];
                count = 0;
                foreach (Symptom sysp in _arrayList)
                {
                    if (sysp != null && sysp.SymptomName.Contains(SymptomName))
                    {
                        symptoms[count] = sysp.DeepCopy(sysp);
                        count += 1;
                    }
                }
                return symptoms;
           
            }



        Symptom[] DiseaseOfPatient.CheckDetail(string SymptomName)
        {
            throw new Exception("Diease is not found");
        }
    }
    }




       
   
