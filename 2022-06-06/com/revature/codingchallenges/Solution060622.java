package com.revature.codingchallenges;

import java.util.Scanner;
import java.lang.Character;
import java.lang.Integer;

public class Solution060622 {

    public static void main(String[] args) {

        Scanner scan = new Scanner(System.in);

        System.out.println("--Find Second-Maximum--");
        System.out.println("Input: ");
        int count1 = scan.nextInt();
        int[] outputs1 = new int[count1];
        for (int i = 0; i < count1; i++) {
            int[] nums = new int[] { scan.nextInt(), scan.nextInt(), scan.nextInt() };
            outputs1[i] = FindSecondMax(nums);
        }
        System.out.println("Output: ");
        for (int i = 0; i < count1; i++) {
            System.out.println(outputs1[i]);
        }

        System.out.println("\n--Sum Digits of String--");
        System.out.println("Input: ");
        int count2 = scan.nextInt();
        int[] outputs2 = new int[count2];
        for (int i = 0; i < count2; i++) {
            String input = scan.next();
            outputs2[i] = SumDigits(input);
        }
        System.out.println("Output: ");
        for (int i = 0; i < count2; i++) {
            System.out.println(outputs2[i]);
        }

        scan.close();
    }

    public static int FindSecondMax(int[] nums) {

        int max = 0;
        int secondMax = 0;
        for (int i = 0; i < nums.length; i++) {
            if (nums[i] > max) {
                secondMax = max;
                max = nums[i];
            } else if (nums[i] > secondMax) {
                secondMax = nums[i];
            }
        }
        return secondMax;
    }

    public static int SumDigits(String str) {

        int sum = 0;
        for (int i = 0; i < str.length(); i++) {
            if (Character.isDigit(str.charAt(i))) {
                sum += Integer.parseInt(str.substring(i, i + 1));
            }
        }
        return sum;
    }
}