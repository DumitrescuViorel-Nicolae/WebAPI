namespace Models
{
    public class BaseModel
    {
        public object this[string colName]
        {
            get
            {
                object val = GetType().GetProperty(colName).GetValue(this);
                return val;
            }
            set
            {
                GetType().GetProperty(colName).SetValue(this, value);
            }
        }
    }
}
