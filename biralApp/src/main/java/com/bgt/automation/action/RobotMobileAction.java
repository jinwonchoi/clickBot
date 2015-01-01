package com.bgt.automation.action;

import org.apache.log4j.Logger;

import com.bgt.automation.util.CommonConst;
import com.bgt.automation.util.Utils;
import com.bgt.mybatis.vo.ActionItem;

public class RobotMobileAction extends BaseAction {

	static Logger Log = Logger.getLogger(RobotMobileAction.class);

	public RobotMobileAction(ActionItem item)
			throws Exception {
		super(item);
		if (!CommonConst.DEVICE_MOBILE.get().equals(item.getDeviceType()) )
			throw new Exception("모바일작업인데 웹브라우저로 설정.");
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
}
