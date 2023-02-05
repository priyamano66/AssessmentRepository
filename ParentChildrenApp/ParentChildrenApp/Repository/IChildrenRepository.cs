using ParentChildrenApp.Models;
using ParentChildrenApp.Models.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParentChildrenApp.Repository
{
    public interface IChildrenRepository
    {
       List<ChildModel> GetMyChildren(int parentId);
        bool AddChildren(ChildDTO childinfo);
        bool EditChildren(ChildDTO childinfo);
       bool DeleteChildren(int childId);
    }
}
