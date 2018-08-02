using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ginger.Dao;
using Ginger.Dto;

namespace Ginger
{
    public partial class CompanyForm : Form
    {
        private BindingList<Company> _companies;

        private CompanyDao _companyDao;

        public CompanyForm()
        {
            InitializeComponent();
            dataGridViewCompanies.AutoGenerateColumns = false;

            _companyDao = new CompanyDao();
            var companies = _companyDao.GetAll();
            _companies = new BindingList<Company>(companies);
            
            dataGridViewCompanies.DataSource = _companies;
        }
    }
}
