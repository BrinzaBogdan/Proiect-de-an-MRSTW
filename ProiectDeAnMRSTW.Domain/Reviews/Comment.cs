using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDeAnMRSTW.Domain.Reviews;

//public sealed record Comment(string Value);

public class Comment
{
    public string Value { get; set; }
    public Comment(string value)
    {
        Value = value;
    }
    public Comment() { }
}