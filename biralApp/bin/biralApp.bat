title 보궁 바이럴 프로그램 시작...

echo "바이럴 프로그램 시작.."

#!/bin/sh

cd ..
set APP_HOME=%cd%
cd bin
rem set JAVA_OPTIONS="-Dbatch_home=${BATCH_HOME} -Dlog4j.logfile.dir=${LOG_FILE_DIR} -Dlog4j.logfile.name=${JOB_ID}"

set JAVA_OPTIONS=-Dapp_home=%APP_HOME% -Dserver_id=000 -Dforced=false
rem set JVM_MEM="-Xms128M -Xmx2048M"

java -jar %app_home%\biralApp-1.0.0.jar -Dapp_home=%APP_HOME% -Dserver_id=000 -Dforced=false

rem java ...
