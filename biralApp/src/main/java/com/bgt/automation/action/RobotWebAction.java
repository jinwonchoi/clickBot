package com.bgt.automation.action;

import org.apache.log4j.Logger;

import com.bgt.automation.util.CommonConst;
import com.bgt.automation.util.Utils;
import com.bgt.mybatis.vo.ActionItem;

/**
 * 개념: Monkey surfing을 1분간 수행
 * 1. 랜덤키워드 입력
 * 2. 유머, 뉴스 등 지정된 section을 클릭
 * 3. 10초간 scrolling
 * 4. 하단 목록중 하나를 클릭
 *  또는 Home 복귀
 * 5. 1~4회 반복후 종료시점
 *   active tab을 home으로 복귀
 *   이때 나머지 탭은 종료
 *   
 *   ** target link클릭시 mouse이동시킴 
 *   
 * @author jinnonsbox
 * 생성일 : 2014. 11. 1.
 */
public class RobotWebAction extends BaseAction {

	static Logger Log = Logger.getLogger(RobotWebAction.class);

	public RobotWebAction(ActionItem item)
			throws Exception {
		super(item);
		if (!CommonConst.DEVICE_WEB.get().equals(item.getDeviceType()) )
			throw new Exception("웹작업인데 모바일브라우저로 설정.");
		Log.info(String.format("%s created. siteType[%s], browserType[%s]",this.getClass().getSimpleName(),item.getSiteType(), item.getBrowserType()));
		Log.info(item.toString());
	}

	@Override
	public void doExecute() {
		Log.info("==================================================================================");
		Log.info(String.format("%s doExecute 시작.",this.getClass().getSimpleName()));
		Utils.waitLongRandomTime();
		Log.info(String.format("%s doExecute 종료.",this.getClass().getSimpleName()));
		Log.info("==================================================================================");
	}
	
	/**
	 * 약 1분간 
	 */
	public void doAnything() {
		
	}
	
}
