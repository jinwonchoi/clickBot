using System;
using System.Collections.Generic;
using System.Text;

namespace PreDeployer
{
    class MySqlBuilder
    {
        //
        //zip파일 찾기
        //<1. DB설치>
        //-1. 기존에 설치된 DB가 있는지 확인한다.
        //-2. 기존의 DB를 삭제할지 확인한다.
        //-3. 기존 DB 삭제하지 않는 경우 DB구조패치하고 <2.DB 데이터 생성>로 이동
        //-4. 기존 DB 삭제하는 경우
        //     => 기존 DB백업(파일로 백업, 파일백업은 추후 수작업복구 또는 복구툴 사용)
        //     => 기존 DB서비스 중지, 삭제
        //-4. DB 삭제
        //-5. DB 설치
        //-6. 3306 포트 사용가능 여부 확인
        //     이미 사용중이면 1씩 증가 시켜 확인
        //    my.conf파일에 적용
        //-7. DB생성
        //-8. DB쿼리 테스트
        //  실패한 경우 리포트
        //<2.DB 데이터 생성>
        //-1. 기존 데이터있는지 확인한다.
        //-2. 회사코드를 입력받음
        //-3. 회사코드가 다를 경우 확인후 변경
        //-4. 신규인 경우 입력받은 회사코드로 생성
        //-5. 회사코드가 같을 경우 확인후 다음단계
        //<2. WeDo서버 설치>
        //-1. 기존에 설치된 서버가 있는지 확인
        //-2. 기존설정유지할지 확인
        //-3. 유지할경우 config파일 백업
        //-4. 기존 파일 삭제
        //-5. 서버파일 설치(원래 의미대로 설치)
        //-6. config파일 복구
        //-7. DB설정 검색해서 config파일 반영(보여줌)
        //-8. 회사코드 검색해서 config파일 반영(보여줌)


        //<1. DB설치>
        //-1. 기존에 설치된 DB가 있는지 확인한다.
        public bool HasWeDoDbInstalled()
        {
            return true;
        }
        //-2. 기존의 DB를 삭제할지 확인한다.
        public bool SetPrevDbNeedRemove()
        {
            return true;
        }

        public bool RemovePrevDb()
        {
            return true;
        }
        //-3. 기존 DB 삭제하지 않는 경우 DB구조패치하고 <2.DB 데이터 생성>로 이동
        public bool UpdateDbSchema()
        {
            return true;
        }
        //-4. 기존 DB 삭제하는 경우
        //     => 기존 DB백업(파일로 백업, 파일백업은 추후 수작업복구 또는 복구툴 사용)
        private bool BackupPrevDb()
        {
            return true;
        }
        //     => 기존 DB서비스 중지, 삭제
        private bool StopDbService()
        {
            return true;
        }
        //-4. DB 삭제
        private bool DeleteDb()
        {
            return true;
        }
        //-5. DB 설치
        private bool InstallDb()
        {
            return true;
        }
        //-6. 3306 포트 사용가능 여부 확인
        //     이미 사용중이면 1씩 증가 시켜 확인
        //    my.conf파일에 적용
        //-7. DB생성
        //-8. DB쿼리 테스트
        //  실패한 경우 리포트
        //<2.DB 데이터 생성>
        //-1. 기존 데이터있는지 확인한다.
        //-2. 회사코드를 입력받음
        //-3. 회사코드가 다를 경우 확인후 변경
        //-4. 신규인 경우 입력받은 회사코드로 생성
        //-5. 회사코드가 같을 경우 확인후 다음단계
        //<2. WeDo서버 설치>
        //-1. 기존에 설치된 서버가 있는지 확인
        //-2. 기존설정유지할지 확인
        //-3. 유지할경우 config파일 백업
        //-4. 기존 파일 삭제
        //-5. 서버파일 설치(원래 의미대로 설치)
        //-6. config파일 복구
        //-7. DB설정 검색해서 config파일 반영(보여줌)
        //-8. 회사코드 검색해서 config파일 반영(보여줌)
    
    
    }
}
