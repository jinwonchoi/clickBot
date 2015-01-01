package com.bgt.automation.util;

import java.io.*;
import java.net.*;
import java.util.*;

public class ListNets {

  public static void main(String args[])
      throws SocketException {
    Enumeration<NetworkInterface> nets =
      NetworkInterface.getNetworkInterfaces();
    for (NetworkInterface netint : Collections.list(nets)) {
      displayInterfaceInformation(netint);
    }
  }

  private static void displayInterfaceInformation(
      NetworkInterface netint) throws SocketException {
    System.out.printf(
        "Display name: %s%n", netint.getDisplayName());
    System.out.printf("Name: %s%n", netint.getName());
    Enumeration<InetAddress> inetAddresses = 
        netint.getInetAddresses();
    for (InetAddress inetAddress : Collections.list(
        inetAddresses)) {
    System.out.printf("InetAddress: %s%n", inetAddress);
    }
   System.out.printf("%n");
  }
}  