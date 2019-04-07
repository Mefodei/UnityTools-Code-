﻿using System;
using System.Collections;
using UniModule.UnityTools.Interfaces;
using UniModule.UnityTools.UniRoutine;
using UnityEngine;

namespace UniModule.UnityTools.Extension
{
    public static class RoutineExtension
    {

        public static IEnumerator RoutineWaitUntil(this ICompletionStatus status) {

            if(status == null)yield break;
            
            while (status.IsComplete == false) {
                yield return null;
            }

        }

        public static IEnumerator RoutineWaitUntil(this Func<bool> completeFunc)
        {

            if (completeFunc == null) yield break;
            while (completeFunc() == false)
            {
                yield return null;
            }

        }

        public static IEnumerator WaitForSecond(this object source,float delay)
        {
            var time = 0f;
            while (time < delay)
            {
                yield return null;
                time += UnityEngine.Time.deltaTime;
            }
        }
        
        public static IEnumerator WaitForSecondUnscaled(this object source,float delay)
        {
            var time = UnityEngine.Time.realtimeSinceStartup;
            var endOfAwait = time + delay;
            while (time < endOfAwait)
            {
                yield return null;
                time = UnityEngine.Time.realtimeSinceStartup;
            }
        }
        
        public static IEnumerator WaitUntil(this object source, Func<bool> completeFunc)
        {

            if (source == null || completeFunc == null) yield break;
            while (completeFunc() == false)
            {
                yield return null;
            }

        }

        public static IEnumerator WaitWhile(this object source, Func<bool> completeFunc)
        {

            if (completeFunc == null) yield break;
            while (completeFunc())
            {
                yield return null;
            }

        }

        public static IEnumerator ExecuteWhile(this object target, Func<IEnumerator> sequence, Func<bool> condition)
        {
            
            if(sequence == null || condition == null)yield break;

            while (condition())
            {
                yield return sequence();
                yield return null;
            }
            
        }

        
        public static IDisposable ExecuteWithCondition(this object target, 
            Action action, Func<bool> condition,
            Func<bool> awaiter,
            RoutineType routineType = RoutineType.UpdateStep)
        {
            
            var enumerator = ExecuteWhen(target,action, condition,awaiter);
            var disposable = enumerator.RunWithSubRoutines(routineType);
            return disposable;
            
        }

        public static IDisposable ExecuteWithCondition(this object target, 
            Action action, Func<bool> condition,
            RoutineType routineType = RoutineType.UpdateStep)
        {
            
            var enumerator = ExecuteWhile(target,action, condition);
            var disposable = enumerator.RunWithSubRoutines(routineType);
            return disposable;
            
        }
        
        /// <summary>
        /// execute target action when condition is true, repeat until awaiter is true
        /// </summary>
        /// <param name="target">target object</param>
        /// <param name="action">target action</param>
        /// <param name="condition">action condition</param>
        /// <param name="awaiter">awaiter</param>
        /// <returns>progress awaiter</returns>
        public static IEnumerator ExecuteWhen(this object target, Action action, Func<bool> condition,
            Func<bool> awaiter)
        {
                        
            while (awaiter())
            {
                if (condition())
                {
                    action();
                }
                yield return null;
            }

        }
        
        
        /// <summary>
        /// repeat target action until condition is true
        /// </summary>
        /// <returns>progress enumerator</returns>
        public static IEnumerator ExecuteWhile(this object target, Action action, Func<bool> condition)
        {

            while (condition())
            {
                action();
                yield return null;
            }
            
        }
        
        public static IEnumerator RoutineWaitUntil(this AsyncOperation operation) {

            if(operation == null)yield break;
            
            while (operation.isDone == false) {
                yield return null;
            }

        }
        
    }
}