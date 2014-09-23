using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class DB
    {
        /// <summary>
        /// 查询表中的所有数据
        /// </summary>
        /// <returns></returns>
        public static IQueryable<Student> getData()
        {
            DbConStudent db = new DbConStudent();
            var query = from s in db.Student
                        select s;
            return query;
        }

        /// <summary>
        /// 查询特定id的Student
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Student getDataById(int id)
        {
            DbConStudent db = new DbConStudent();
            var query = from s in db.Student
                        where s.ID == id
                        select s;
            List<Student> list = query.ToList<Student>();
            if (list.Count > 0)
            {
                return list[0];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="st"></param>
        public static void InsertToDb(Student st)
        {
            DbConStudent db = new DbConStudent();
            db.Student.InsertOnSubmit(st);
            db.SubmitChanges();
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="id">要修改的id</param>
        /// <param name="st">全新的STUDENT</param>
        public static void ChangeRow(int id,Student st) 
        {
            DbConStudent db = new DbConStudent();
            var editStudent = db.Student.SingleOrDefault<Student>(s => s.ID == 1);

            if (editStudent == null)
            {                
                return;
            }

            //修改student的属性
            editStudent = st;

            //执行更新操作
            db.SubmitChanges();

        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="st"></param>
        public static void Delete(Student st)
        {
            DbConStudent db = new DbConStudent();
            db.Student.DeleteOnSubmit(st);
            db.SubmitChanges();
        }
    }
}

