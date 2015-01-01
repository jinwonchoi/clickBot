package com.bgt.automation.action;

import org.apache.log4j.Logger;

import com.bgt.automation.util.CommonConst;
import com.bgt.automation.util.Utils;
import com.bgt.mybatis.vo.ActionItem;

public class DummyAction extends BaseAction {
	static Logger Log = Logger.getLogger(DummyAction.class);

	public DummyAction(ActionItem item)
			throws Exception {
		super(item);
		Log.info(String.format("%s created. siteType[%s], browserType[%s]",this.getClass().getSimpleName(),item.getSiteType(), item.getBrowserType()));
		Log.info(item.toString());
	}
	
	//
	void doNothing(int sec) {
		try {
			Thread.sleep(sec*1000);
		} catch (InterruptedException e) {
			Log.error("doNothing",e);
		}
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
