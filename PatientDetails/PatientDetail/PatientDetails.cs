using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientDetail
{
   
    class Disease
    {
        public int DiseaseId { get; set; }
        public string DiseaseName { get; set; }
        public string Severity { get; set; }
        public string Cause { get; set; }
        public string Description { get; set; }
    }
    class Symptom : Disease
    {
        internal readonly object PatientName;

        public int SymptomId { get; set; }
        public string SymptomName { get; set; }
        internal void ShallowCopy(Symptom copy)
        {
            this.SymptomId = copy.SymptomId;
            this.SymptomName = copy.SymptomName;

        }
        public Symptom DeepCopy(Symptom copy)
        {
            Symptom symptom = new Symptom();
            symptom.ShallowCopy(copy);
            return symptom;
        }
    }
    class PatientDetails : Symptom
    {
        private int size;

        public PatientDetails(int size)
        {
            this.size = size;
        }

        public int PatientId { get; set; }
        public new string PatientName { get; set; }
        public int Checkpatients { get; private set; } 
  
    }

}
