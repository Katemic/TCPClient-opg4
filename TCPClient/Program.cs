using System.Net.Sockets;


Console.WriteLine("This is the TCP Client");

bool keepSending = true;

TcpClient socket = new TcpClient("127.0.0.1", 7);


NetworkStream ns = socket.GetStream();
StreamReader reader = new StreamReader(ns);
StreamWriter writer = new StreamWriter(ns);

while (keepSending)
{
    Console.WriteLine("Pick a method");
    string message = Console.ReadLine();

    writer.WriteLine(message);

    writer.Flush();


    string response = reader.ReadLine();
    if (response == "Input numbers")
    {
        Console.WriteLine("Enter number 1");
        int number1 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter number 2");
        int number2 = Convert.ToInt32(Console.ReadLine());

        string numbers = number1 + " " + number2;
        writer.WriteLine(numbers);
        writer.Flush();

        response = "Server response:" + reader.ReadLine();

    }

    Console.WriteLine(response);

    if (message.ToLower() == "stop")
    {
        keepSending = false;
    }


}
    
    