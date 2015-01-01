package com.bgt.automation.util.event;

public interface TaskEventListener extends java.util.EventListener {
	public void scheduleRetryTask(TaskEvent e);
	public void scheduleNormalTask(TaskEvent e);
	public void scheduleNextPeriodTask(TaskEvent e);
}
