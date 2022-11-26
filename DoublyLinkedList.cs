using System;

class ListItem
{
    public int Id;
    public string? Name;
    public ListItem? nextitem;
    public ListItem? previtem;
    public ListItem(int x, string y)
    {
        Id = x; Name = y;       
        nextitem = null; 
        previtem = null; 
    }
}

class List
{
    ListItem? head;
    ListItem? tail;
    public List() { head = null; }  
    
    public void AddItem(int x, string y)
    {
        ListItem newitem = new ListItem(x,y);

        if(tail == null)
        {
            tail = newitem;
            head = newitem;
        }
        else
        {
            newitem.previtem = tail;
            tail.nextitem = newitem;
            tail = newitem;
        }

    }

    public void AddItem2(int x, string y)
    {
        ListItem newitem = new ListItem(x, y);
        
        if(head != null)
        {
            head.previtem = newitem;
            newitem.nextitem = head;
            head = newitem;
        }    

    }

    public void AddItem3(int x, string y, int z)
    {
        ListItem? Curr = head;

        ListItem newitem = new ListItem(x, y);

        int count = 1;
        while (Curr != null)
        {
            if(Curr.nextitem != null && count ==  z-1)
            {
                newitem.nextitem = Curr.nextitem;
                Curr.nextitem.previtem = newitem;
                newitem.previtem = Curr;
                Curr.nextitem = newitem;
                break;

            }

            Curr = Curr.nextitem;
            count++;
        }

    }

    public void DeleteItem(int x)
    {
        ListItem? Curr = head;
        ListItem? Prev = head;
        ListItem? Next = head;  

        while (Curr != null)
        {
            if(Curr.previtem != null && Curr.nextitem != null)
            {
                Prev = Curr.previtem;
                Next = Curr.nextitem;

                if(Curr.Id==x)
                {
                    Prev.nextitem = Next;   
                    Next.previtem = Prev;
                }

            }

            else if(Curr.previtem == null && Curr.Id == x && Curr.nextitem != null)
            {
                Curr.nextitem.previtem = null;
                head = Curr.nextitem;

            }

            else if (Curr.nextitem == null && Curr.previtem != null)
            {
                if(Curr.Id == x)
                {
                    Prev = Curr.previtem;
                    Prev.nextitem = null;
                }
            }

            else if (Curr.nextitem == null && Curr.previtem == null)
            {
                if (Curr.Id == x)
                {
                    head = null;
                }
            }

            Curr = Curr.nextitem;
        }
        

    }

    public void PrintList()
    {
        ListItem? temp = head;

        if (temp == null)
        {
            Console.WriteLine("* Liste Boş.");
        }
        Console.WriteLine();
        Console.WriteLine("  *Liste: ");
        while (temp != null)
        {
            Console.WriteLine("  " +  temp.Id + "-" + temp.Name);
            temp = temp.nextitem;
        }
        Console.WriteLine();
        Console.WriteLine("------------------------------------------------------");


    }

}

class MainClass
{
    public static void Main()
    {
        List list = new List();
        list.AddItem(1, "Bir");
        list.AddItem(2, "İki");
        list.AddItem(4, "Dört");
        list.AddItem2(0, "Sıfır");
        list.AddItem3(3, "Üç",4);




        while (true)
        {
            Console.Write("1 - Sona Ekle\n2 - Başa Ekle\n3 - Araya Ekle\n4 - Sil\n5 - Listeyi GÖster\n\nİşlem Seçin:");
            int input =  Convert.ToInt32(Console.ReadLine());
            if (input == 1)
            {
                Console.Write("Id Girin: ");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.Write("İsim Girin: ");
                string? name = Console.ReadLine();
                list.AddItem(id, name); 
                Console.WriteLine();
                list.PrintList();
            }
            if (input == 2)
            {
                Console.Write("Id Girin: ");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.Write("İsim Girin: ");
                string? name = Console.ReadLine();
                list.AddItem2(id, name);
                Console.WriteLine();
                list.PrintList();
            }
            if (input == 3)
            {
                Console.Write("Eklemek İstediğiniz Sırayı Girin: ");
                int count = Convert.ToInt32(Console.ReadLine());
                Console.Write("Id Girin: ");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.Write("İsim Girin: ");
                string? name = Console.ReadLine();
                list.AddItem3(id, name, count);
                Console.WriteLine();
                list.PrintList();
            }
            if (input == 4)
            {
                Console.Write("Silmek İçin Id Girin: ");
                int id = Convert.ToInt32(Console.ReadLine());
                list.DeleteItem(id);
                Console.WriteLine();
                list.PrintList();
            }
            if (input == 5)
            {
                list.PrintList();
            }
        }



    }
}