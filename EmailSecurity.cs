using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public interface IEmailProtocol
    {
        void ProtocolIinformation();
    }

    public class OldEmailProtocol : IEmailProtocol
    {
        public void ProtocolIinformation()
        {
            Console.WriteLine("Old Protocol");
        }
    }

    public class NewEmailProtocol : IEmailProtocol
    {
        public void ProtocolIinformation()
        {
            Console.WriteLine("New Protocol");
        }
    }

    public interface ISecureEmail
    {
        IEmailProtocol Protocol { get; set; }

        void Secure();
    }

    public class DOSSecurity : ISecureEmail
    {
        public DOSSecurity(IEmailProtocol protocol)
        {
            Protocol = protocol;
        }

        public IEmailProtocol Protocol { get; set; }

        public void Secure()
        {
            Console.WriteLine("Windows:");
            Protocol.ProtocolIinformation();
        }
    }

    public class MacSecurity : ISecureEmail
    {
        public MacSecurity(IEmailProtocol protocol)
        {
            Protocol = protocol;
        }

        public IEmailProtocol Protocol { get; set; }
        public void Secure()
        {
            Console.WriteLine("Mac:");
            Protocol.ProtocolIinformation();
        }
    }
    public abstract class UpgradedSecurity : ISecureEmail
    {
        public virtual IEmailProtocol Protocol { get; set; }
        private ISecureEmail secureType;
        protected UpgradedSecurity(ISecureEmail secureType)
        {
            Protocol = secureType.Protocol;
            SecureType = secureType;
        }

        public virtual ISecureEmail SecureType { get => secureType; set => secureType = value; }

        public virtual void Secure()
        {
            SecureType.Secure();
        }
    }

    public class MacOSX : UpgradedSecurity
    {
        public MacOSX(ISecureEmail secureType) : base(secureType)
        {
        }

        public override void Secure()
        {
            Console.WriteLine("MacOSX");
            base.Secure();

        }
    }

    public class WinXP : UpgradedSecurity
    {
        public WinXP(ISecureEmail secureType) : base( secureType)
        {
        }
        public override void Secure()
        {
            Console.WriteLine("WinXP");
            base.Secure();

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IEmailProtocol protocol = new OldEmailProtocol();
            ISecureEmail secureEmail = new DOSSecurity(protocol);
            secureEmail.Secure();
            secureEmail = new MacSecurity(protocol);
            secureEmail.Secure();
            protocol = new NewEmailProtocol();
            secureEmail = new WinXP(new DOSSecurity(protocol));
            secureEmail.Secure();
            secureEmail = new MacOSX(new MacSecurity(protocol));
            secureEmail.Secure();
            Console.ReadLine();

        }
    }
}
