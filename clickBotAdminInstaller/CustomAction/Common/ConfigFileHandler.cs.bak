using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;

namespace WeDoCommon
{
    class ConfigFileHandler
    {
        string configDir;
        string configFile;
        string backupConfigFile;

        public ConfigFileHandler(string configDir, string configFile)
        {
//#if (DEBUG)
//            this.configDir = "";
//#else
            this.configDir = configDir;
//#endif
            this.configFile = configFile;
            this.backupConfigFile = configFile + ".config";
            Logger.info(string.Format("ConfigFileHandler생성: 경로[{0}] 파일[{1}]",configDir, configFile));
        }

        /// <summary>
        /// backup된 config를 읽어 save된 정보를 
        /// 새로 install한 config에 저장한다.
        /// </summary>
        public void RecoverConfig()
        {
            Configuration backupConfig = GetBackupConfig();
            KeyValueConfigurationCollection backupConfCollection = backupConfig.AppSettings.Settings;

            Configuration exeConfig = GetExeConfig();
            KeyValueConfigurationCollection exeConfCollection = exeConfig.AppSettings.Settings;

            foreach (KeyValueConfigurationElement el in backupConfCollection)
            {
                string key = el.Key;
                string val = el.Value;

                if (exeConfCollection[key] == null)
                {
                    continue;
                }
                string exeValue = exeConfCollection[key].Value;
                
                if (!val.Equals(exeValue))
                {
                    exeConfCollection[key].Value = val;
                    Logger.info(string.Format("config 복구: old item[{0}][{1}]==> new item[{2}][{3}]"
                        , key, val, key, exeValue));
                }
                // do something with key and value
            }
            exeConfig.Save(ConfigurationSaveMode.Modified);
        }

        /// <summary>
        /// config폴더가 없는 경우 
        /// 폴더생성하고 config파일을 복사함.
        /// </summary>
        public void BackupConfig()
        {
            Configuration config = GetExeConfig();//"C:\\eclues\\WeDo Server\\WD_Server.exe");

            if (!config.HasFile)
            {
                Logger.info("config파일 백업 skip : WeDo 미설치상태");
            }
            else
            {
                string newDir = ConstDef.APP_DATA_CONFIG_DIR;//"C:\\eclues\\AppData\config\\";
                string fileName = backupConfigFile;//"WD_Server.exe.config";

                if (!Directory.Exists(newDir))
                    Directory.CreateDirectory(newDir);

                config.SaveAs(newDir + fileName, ConfigurationSaveMode.Minimal, true);
                Logger.info(string.Format("config파일[{0}] 백업", newDir + fileName));

            }
        }

        private Configuration GetBackupConfig()
        {
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
            fileMap.ExeConfigFilename = ConstDef.APP_DATA_CONFIG_DIR + backupConfigFile;//@"C:\eclues11\backup\WD_Server.exe.config";
            // Open another config file
            return ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
        }

        private Configuration GetExeConfig()
        {
            return ConfigurationManager.OpenExeConfiguration(configDir + configFile);//"C:\\eclues\\WeDo Server\\WD_Server.exe");
        }

        /// <summary>
        /// config폴더에 백업된 config파일이 존재하는지 확인
        /// </summary>
        /// <returns></returns>
        public bool PrevConfigExists()
        {
            bool result = false;

            try
            {
                if (GetBackupConfig().HasFile)
                {
                    result = true;
                }
            }
            catch (Exception e)
            {
                Logger.error("PrevConfigExists 오류"+e.ToString());
                result = false;
            }
            return result;

        }

        /// <summary>
        /// install된 config파일에 새 값을 저장
        /// 값이 다를 경우 config폴더에도 등록함.
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetValue(string key, string value)
        {
            try
            {
                Configuration exeConfig = GetExeConfig();
                KeyValueConfigurationCollection exeConfigCollection = exeConfig.AppSettings.Settings;
                if (exeConfigCollection[key] != null)
                    exeConfigCollection[key].Value = value;

                exeConfig.Save(ConfigurationSaveMode.Modified);

                Configuration backupConfig = GetBackupConfig();
                if (!backupConfig.HasFile)
                {
                    BackupConfig();
                    backupConfig = GetBackupConfig();
                }
                KeyValueConfigurationCollection backupConfCollection = backupConfig.AppSettings.Settings;
                if (backupConfCollection[key] != null && !value.Equals(backupConfCollection[key].Value))
                {
                    backupConfCollection[key].Value = value;
                    backupConfig.Save(ConfigurationSaveMode.Modified);
                }
            }
            catch (Exception ex) {
                Logger.error("SetValue중 에러:" + ex.ToString());
                throw new Exception("SetValue중 에러");
            }

            return true;
        }

        /// <summary>
        /// config값을 가져옴.
        /// config폴더와 응용프로그램폴더의 각 config파일은 동일하다고 판단하고,
        /// config폴더의 config파일의 값을 가져옴
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetValue(string key)
        {
            Configuration exeConfig = GetExeConfig();
            KeyValueConfigurationCollection exeConfigCollection = exeConfig.AppSettings.Settings;
            if (exeConfigCollection[key] == null)
                return null;
            else
                return exeConfigCollection[key].Value;
        }

        public bool KeyExistsInCurrentConfig(string key)
        {
            Configuration exeConfig = GetExeConfig();
            KeyValueConfigurationCollection exeConfigCollection = exeConfig.AppSettings.Settings;
            return (exeConfigCollection[key] != null);
        }

        public string BackupCompanyCd()
        {
            string result = "";
            Configuration backupConfig = GetBackupConfig();
            if (backupConfig.HasFile)
            {
                KeyValueConfigurationCollection backupConfigCollection = backupConfig.AppSettings.Settings;
                result = backupConfigCollection["COM_CODE"].Value;
            }
            return result;
        }

        public string BackupCompanyName()
        {
            string result = "";
            Configuration backupConfig = GetBackupConfig();
            if (backupConfig.HasFile)
            {
                KeyValueConfigurationCollection backupConfigCollection = backupConfig.AppSettings.Settings;
                result = backupConfigCollection["COM_NAME"].Value;
            }
            return result;
        }


        string companyCd = "";

        public string CompanyCd
        {
            get { return companyCd; }
            set { companyCd = value; }
        }

        string companyName = "";

        public string CompanyName
        {
            get { return companyName; }
            set { companyName = value; }
        }
    }
}
