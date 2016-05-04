using System.Threading;

namespace OSPF
{
    public class Message
    {

        private Router router;
        private string dest;
        private string text;

        public Message(Router router, string dest, string text)
        {
            this.router = router;
            this.dest = dest;
            this.text = text;
            run();
        }

        public void run()
        {
            router.SendMessage(dest, text);
        }
    }
}
