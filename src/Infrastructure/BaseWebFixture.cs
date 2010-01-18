namespace Infrastructure
{
    public abstract class BaseWebFixture
    {
        protected  IBrowser Browser { get; private set;}


        protected BaseWebFixture()
        {
            Browser = new SeleniumBrowser();
        }

        public virtual void SetUp()
        {
            Browser.StartSession();          
        }

        public virtual void TearDown()
        {
            Browser.StopSession();
        }
        

    }
}