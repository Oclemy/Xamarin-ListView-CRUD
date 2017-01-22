using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Collections;

namespace ListView_CRUD
{
    class CRUD
    {
        ArrayList players;
        ArrayAdapter adapter;

        public CRUD(ArrayAdapter adapter,ArrayList list)
        {
            this.adapter = adapter;
            this.players = list;
        }

        public Boolean add(String name)
        {
            try
            {
                players.Add(name);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public Boolean update(String newName,int id)
        {
            try
            {
                players.RemoveAt(id);
                players.Insert(id, newName);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public Boolean delete(int id)
        {
            try
            {
                players.RemoveAt(id);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public void clear()
        {
            players.Clear();
        }



    }
}