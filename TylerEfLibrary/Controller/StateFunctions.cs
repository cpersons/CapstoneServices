using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TylerEfLibrary
{
    public class StateFunctions
    {
        private ReportModel db = new ReportModel();

        //Return all states
        public List<tblState> getStates()
        {
            var states = db.tblStates;
            return states.ToList<tblState>();
        }

        public tblState stateById(int id) {
            return db.tblStates.Find(id);
        }

    }
}
