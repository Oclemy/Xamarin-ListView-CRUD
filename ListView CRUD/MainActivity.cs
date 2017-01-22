using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections;

namespace ListView_CRUD
{
    [Activity(Label = "ListView CRUD", MainLauncher = true, Icon = "@drawable/simplesmile")]
    public class MainActivity : Activity
    {
        ArrayList names;
        ListView lv;
        ArrayAdapter adapter;
        CRUD crud;
        EditText nameTxt;
        Button addBtn, updateBtn, deleteBtn,clearBtn;
        int selectedItem = -1;


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            lv = FindViewById<ListView>(Resource.Id.lv);
            nameTxt = FindViewById<EditText>(Resource.Id.nameTxt);
            addBtn = FindViewById<Button>(Resource.Id.addBtn);
            updateBtn = FindViewById<Button>(Resource.Id.updateBtn);
            deleteBtn = FindViewById<Button>(Resource.Id.deleteBtn);
            clearBtn = FindViewById<Button>(Resource.Id.clearBtn);


           names = new ArrayList();

           adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, names);
           lv.Adapter = adapter;

           crud = new CRUD(adapter, names);

           lv.ItemClick += lv_ItemClick;
           addBtn.Click += addBtn_Click;
           updateBtn.Click += updateBtn_Click;
           deleteBtn.Click += deleteBtn_Click;
           clearBtn.Click += clearBtn_Click;
           
        }

        void clearBtn_Click(object sender, EventArgs e)
        {
            crud.clear();
            nameTxt.Text = "";
            adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, names);
            lv.Adapter = adapter;
        }

        void deleteBtn_Click(object sender, EventArgs e)
        {
            if (crud.delete(selectedItem))
            {
                nameTxt.Text = "";
                adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, names);
                lv.Adapter = adapter;
            }
        }

        void updateBtn_Click(object sender, EventArgs e)
        {
            if(crud.update(nameTxt.Text, selectedItem))
            {
                adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, names);
                lv.Adapter = adapter;
            }
        }

        void addBtn_Click(object sender, EventArgs e)
        {
            if(crud.add(nameTxt.Text))
            {
                nameTxt.Text = "";
                adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, names);
                lv.Adapter = adapter;
            }
   
        }

        void lv_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            this.selectedItem = e.Position;
            nameTxt.Text = names[selectedItem].ToString();
        }

    }
}

