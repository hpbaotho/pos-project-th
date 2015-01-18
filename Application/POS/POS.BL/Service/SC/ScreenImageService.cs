using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using POS.BL.Entities.Entity;
using System.Transactions;
using Core.Standards.Validations;

namespace POS.BL.Service.SC
{
    public class ScreenImageService : ServiceBase<ScreenImage>
    {
        public void ClearImgeByParentControl(long? parentControlId)
        {
            TransactionOptions tranOpt = new TransactionOptions() { IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted };
            using (var trans = new TransactionScope(TransactionScopeOption.Required, tranOpt))
            {
                string sql = @"

                    UPDATE sc_screen_config SET sc_screen_image_id=null
                    WHERE control_parent_id=@control_parent_id

                    DELETE sc_screen_image
                    WHERE EXISTS(
                    SELECT 'x' FROM sc_screen_config WHERE sc_screen_config.control_parent_id=@control_parent_id
                    AND sc_screen_config.control_id=sc_screen_image.control_id
                    )
                ";
                List<DbParameter> param = new List<DbParameter>();
                param.Add(base.CreateParameter("@control_parent_id", parentControlId));
                this.ExecuteQuery(sql, param);


                string deleteImageParent = @"
                            UPDATE sc_screen_config SET sc_screen_image_id=null
                            WHERE control_id=@control_parent_id

                            DELETE sc_screen_image
                            WHERE control_id=@control_parent_id
                    ";
                param = new List<DbParameter>();
                param.Add(base.CreateParameter("@control_parent_id", parentControlId));
                this.ExecuteQuery(deleteImageParent, param);


                trans.Complete();
            }

        }
        public void SeveImageControl(ScreenConfig mainScreen, List<ScreenConfig> listControls)
        {
            TransactionOptions tranOpt = new TransactionOptions() { IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted };
            using (var trans = new TransactionScope(TransactionScopeOption.Required, tranOpt))
            {
                List<ScreenConfig> saveControlImage = new List<ScreenConfig>();
                if (listControls != null) saveControlImage = listControls;

                saveControlImage.Add(mainScreen);

                foreach (ScreenConfig itemImage in saveControlImage)
                {
                    if (itemImage.image != null && itemImage.image.Length > 0)
                    {
                        ScreenImage scImage = new ScreenImage();
                        scImage.control_id = itemImage.control_id;
                        scImage.image = itemImage.image;
                        scImage.sc_screen_image_id = this.Insert<long>(scImage, ValidationRuleset.Insert);

                        ScreenConfig UpdateitemImage = ServiceProvider.ScreenConfigService.FindByKeys(itemImage, true);
                        UpdateitemImage.sc_screen_image_id = scImage.sc_screen_image_id;
                        ServiceProvider.ScreenConfigService.Update(UpdateitemImage, ValidationRuleset.Update);

                    }
                }
                trans.Complete();
            }
        }
    }
}
