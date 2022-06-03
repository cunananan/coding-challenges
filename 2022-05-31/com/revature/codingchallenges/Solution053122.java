package com.revature.codingchallenges;

import java.util.List;
import java.util.ArrayList;
import java.util.Collections;

public class Solution053122 {

    public static void main(String[] args) {

        System.out.println("Java - Part a:\n");

        int[] a0 = { 515, 341, 98, 44, 211 };
        int[] a1 = { 515, 341, 98, 44, 211 };
        int[] a2 = { 63251, 78221 };
        int[] a3 = { 63251, 78221 };
        int[] a4 = { 1, 2, 3, 4 };
        int[] a5 = { 1, 2, 3, 4 };

        System.out.println(
                "ReorderDigits(" + IntArrayToString(a0) + ", \"asc\") -> "
                        + IntArrayToString(ReorderDigits(a0, "asc")));
        System.out.println("ReorderDigits(" + IntArrayToString(a1) + ", \"desc\") -> "
                + IntArrayToString(ReorderDigits(a1, "desc")));
        System.out.println(
                "ReorderDigits(" + IntArrayToString(a2) + ", \"asc\") -> "
                        + IntArrayToString(ReorderDigits(a2, "asc")));
        System.out.println("ReorderDigits(" + IntArrayToString(a3) + ", \"desc\") -> "
                + IntArrayToString(ReorderDigits(a3, "desc")));
        System.out.println(
                "ReorderDigits(" + IntArrayToString(a4) + ", \"asc\") -> "
                        + IntArrayToString(ReorderDigits(a4, "asc")));
        System.out.println("ReorderDigits(" + IntArrayToString(a5) + ", \"desc\") -> "
                + IntArrayToString(ReorderDigits(a5, "desc")));

        System.out.println("\nJava - Part b:\n");

        int[] b0 = { 2, 8, 4, 1 };
        int[] b1 = { -1, -10, 1, -2, 20 };
        int[] b2 = { -1, -20, 5, -1, -2, 2 };

        System.out.println("CanPartition(" + IntArrayToString(b0) + ") -> " + (CanPartition(b0) ? "true" : "false"));
        System.out.println("CanPartition(" + IntArrayToString(b1) + ") -> " + (CanPartition(b1) ? "true" : "false"));
        System.out.println("CanPartition(" + IntArrayToString(b2) + ") -> " + (CanPartition(b2) ? "true" : "false"));
    }

    public static int[] ReorderDigits(int[] nums, String orderStr) {

        int order = (orderStr.equals("asc")) ? 1 : (orderStr.equals("desc")) ? -1 : 0;
        for (int i = 0; i < nums.length; i++) {
            nums[i] = ReorderDigitsSingle(nums[i], order);
        }
        return nums;
    }

    public static boolean CanPartition(int[] nums) {

        int target = PopMaxMagnitude(nums);
        int product = 1;
        for (int i = 0; i < nums.length; i++) {
            product *= nums[i];
        }
        return target == product;
    }

    // order > 0 => ascending, order < 0 => descending, order = 0 => noop
    private static int ReorderDigitsSingle(int num, int order) {

        List<Integer> digits = new ArrayList<>();
        do {
            digits.add(num % 10);
            num /= 10;
        } while (num > 0);

        Collections.sort(digits, (a, b) -> {
            if (order > 0)
                return a - b;
            else if (order < 0)
                return b - a;
            else
                return 0;
        });

        int result = 0;
        for (int i = 0; i < digits.size(); i++) {
            result *= 10;
            result += digits.get(i);
        }
        return result;
    }

    private static int PopMaxMagnitude(int[] nums) {

        int max = 0;
        int maxIdx = -1;
        for (int i = 0; i < nums.length; i++) {
            if (Math.abs(nums[i]) > Math.abs(max)) {
                max = nums[i];
                maxIdx = i;
            }
        }
        if (maxIdx >= 0)
            nums[maxIdx] = 1;
        return max;
    }

    private static String IntArrayToString(int[] array) {
        String str = "[ ";
        for (int i = 0; i < array.length; i++) {
            str += array[i] + " ";
        }
        return str + "]";
    }
}