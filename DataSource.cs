using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WpfApp6
{
    class DataSource:INotifyPropertyChanged
    {
       
       
        private Service _fileService;
        public ObservableCollection<Friends> Friends { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        private string name="";
       
        public DataSource(Service fileService)
        {
            _fileService = fileService;
            Friends = new ObservableCollection<Friends>();
           
        }
        protected virtual void OnPropertyChanged(string propertyName = null)
        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
        public string Name
        {
            get => name;
            set
            {
                if (!name.Equals(value))
                {
                    name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }
        private MyCommands _loadCommand;

        public MyCommands LoadCommand
        {

            get
            {

                return _loadCommand ?? (_loadCommand = new MyCommands(obj =>
                {
                    var friends = _fileService.Open("friends.json");
                    Friends.Clear();
                    foreach (var item in friends)
                    {
                        Friends.Add(item);

                    }
                   
                }));

            }



        }
        private MyCommands _addCommand;

        public MyCommands AddCommand
        {

            get
            {

                return _addCommand ?? (_addCommand = new MyCommands(obj =>
                {
                    Friends friend = new Friends(name);
                    Friends.Add(friend);
                 

                }));

            }



        }
        private MyCommands _saveCommand;



        public MyCommands SaveCommand
        {

            get
            {

                return _saveCommand ?? (_saveCommand = new MyCommands(obj =>

                    _fileService.Save("friends.json", Friends.Select(m => new Friends
                    {
                        Name = m.Name,
                        

                  }).ToList())
                    
                ));

               
            }

           

        }
    }


}

