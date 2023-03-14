using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab__1
{
    public class Organizer
    {
        public List<Data> list = new List<Data>();

        public Organizer(Data data)
        {

            list.Add(data);
        }

        public Organizer()
        {

        }
        public void add(Data data)
        {
            this.list.Add(data);
        }

        public void remove(int index)
        {
            if (index < list.Count)
                list.RemoveAt(index);
        }
        public List<Data> findByTime(String time)
        {
            List<Data> tmpList = new List<Data>();
            list.ForEach(item =>
            {
                    
                    int time1 = item.Time.Hours * 3600 + item.Time.Minutes;               
                    int time2 = int.Parse(time.Split(':')[0] ) * 3600 + int.Parse(time.Split(':')[1]);
                    if (time2 >= time1)
                    tmpList.Add(item);
            });
            return tmpList;
        }

        public List<Data> findByCategory(EventType type)
        {
            List<Data> tmpList = new List<Data>();
            list.ForEach(item =>
            {
                if (item.EventType == type)
                    tmpList.Add(item);
            });

            return tmpList;
        }

        public void sortByEvent(int direction = 0)
        {
            list.Sort((x, y) => direction == 0 ?
           String.Compare(x.Event, y.Event) :
           String.Compare(y.Event, x.Event)
           );
        }
    }
}
