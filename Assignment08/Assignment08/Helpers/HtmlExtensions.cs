﻿using System;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Assignment08.Helpers
{
    public static class HtmlExtensions
    {
        public static MvcHtmlString DisplayDateOnlyFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            StringBuilder sb = new StringBuilder();

            var metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            var propName = metadata.PropertyName;
            var value = metadata.Model;

            if (value is DateTime dateValue)
            {
                sb.Append(dateValue.ToString("yyyy-MM-dd"));
            }

            return MvcHtmlString.Create(sb.ToString());
        }

        public static MvcHtmlString DisplayDateTimeFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            StringBuilder sb = new StringBuilder();

            var metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            var propName = metadata.PropertyName;
            var value = metadata.Model;

            if (value is DateTime dateValue)
            {
                sb.Append(dateValue.ToString("yyyy-MM-dd HH:mm:ss"));
            }

            return MvcHtmlString.Create(sb.ToString());
        }

        public static MvcHtmlString EditDateOnlyFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, object additionViewData)
        {
            StringBuilder sb = new StringBuilder();

            var metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            var propName = metadata.PropertyName;
            var value = metadata.Model;

            sb.Append(html.EditorFor(expression, additionViewData));

            return MvcHtmlString.Create(sb.ToString());
        }
    }
}