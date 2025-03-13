using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Test_Wpf_App.Legacy_Code
{

    ///// <summary>
    ///// Defines a delegate that is used to get a value on an object.
    ///// </summary>
    ///// <typeparam name="TResult"></typeparam>
    ///// <typeparam name="TArg"></typeparam>
    ///// <param name="sender"></param>
    ///// <param name="arg"></param>
    ///// <returns></returns>
    //public delegate TReturn MyGetter<TReturn, TArg>(object sender, TArg arg);

    ///// <summary>
    ///// Defines a delegate that is used to set a value on an object.
    ///// </summary>
    ///// <typeparam name="TObject"></typeparam>
    ///// <typeparam name="TValue"></typeparam>
    ///// <param name="sender"></param>
    ///// <param name="obj"></param>
    ///// <param name="value"></param>
    ////public delegate void MySetter<TValue, TObject>(object sender, TObject obj, TValue value);

    static public class MyMethods
    {
        /// <summary>
        /// Increments i if shouldInc is true.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="shouldInc"></param>
        static public int IncIfTrue(ref int i, bool shouldInc)
        {
            if (shouldInc)
            {
                i++;
            }
            return i;
        }

        /// <summary>
        /// Returns the name of the property.
        /// Example: GetPropertyName(() => Property);
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="property"></param>
        /// <returns></returns>
        public static string GetPropertyName<T>(Expression<Func<T>> property)
        {
            var lambda = (LambdaExpression)property;
            MemberExpression memberExpression;

            if (lambda.Body is UnaryExpression)
            {
                var unaryExpression = (UnaryExpression)lambda.Body;
                memberExpression = (MemberExpression)unaryExpression.Operand;
            }
            else
            {
                memberExpression = (MemberExpression)lambda.Body;
            }

            return memberExpression.Member.Name;
        }

    }



    /// <summary>
    /// This class implements the <see cref="T:IPropertyNotification"/>
    /// interface and provides helper methods for derived classes.
    /// </summary>
    public class MyNotifyPropertyChanged : INotifyPropertyChanged
    {
        #region IPropertyNotification
        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion // IPropertyNotification

        #region Methods
        /// <summary>
        /// Raises the <see cref="E:PropertyChanged"/> event.
        /// </summary>
        /// <param name="propertyName">
        /// Name of the property that changed.
        /// </param>
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// Raises the <see cref="E:PropertyChanged"/> event.
        /// </summary>
        /// <param name="e">
        /// The <see cref="PropertyChangedEventArgs"/> instance
        /// containing the event data.
        /// </param>
        protected void NotifyPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:PropertyChanged"/> event.
        /// </summary>
        /// <param name="e">
        /// The <see cref="PropertyChangedEventArgs"/> instance
        /// containing the event data.
        /// </param>
        protected void NotifyPropertyChanged<T>(Expression<Func<T>> property)
        {
            NotifyPropertyChanged(MyMethods.GetPropertyName(property));
        }

        #endregion // Methods        
    }
}
