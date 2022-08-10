using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    #region PhraseCompletedEvent
    static List<Typer> phraseCompleteInvokers = new List<Typer>();
    static List<UnityAction<string, float>> phraseCompleteListeners = new List<UnityAction<string, float>>();
    public static void AddPhraseCompletedInvoker(Typer invoker)
    {
        phraseCompleteInvokers.Add(invoker);
        foreach (UnityAction<string, float> listener in phraseCompleteListeners)
        {
            invoker.AddPhraseCompletedListener(listener);
        }
    }
    public static void AddPhraseCompletedListener(UnityAction<string, float> handler)
    {
        phraseCompleteListeners.Add(handler);
        foreach(Typer invoker in phraseCompleteInvokers)
        {
            invoker.AddPhraseCompletedListener(handler);
        }
    }
    #endregion

    #region TimesUpEvent
    static List<TimeManager> timesUpInvokers = new List<TimeManager>();
    static List<UnityAction> timesUpListeners = new List<UnityAction>();
    public static void AddTimesUpInvoker(TimeManager invoker)
    {
        timesUpInvokers.Add(invoker);
        foreach (UnityAction listener in timesUpListeners)
        {
            invoker.AddTimesUpListener(listener);
        }
    }
    public static void AddTimesUpListener(UnityAction handler)
    {
        timesUpListeners.Add(handler);
        foreach (TimeManager invoker in timesUpInvokers)
        {
            invoker.AddTimesUpListener(handler);
        }
    }
    #endregion

    #region LevelStartedEvent
    static List<ScreenManager> levelStartInvokers = new List<ScreenManager>();
    static List<UnityAction> levelStartListeners = new List<UnityAction>();
    public static void AddLevelStartInvoker(ScreenManager invoker)
    {
        levelStartInvokers.Add(invoker);
        foreach (UnityAction listener in levelStartListeners)
        {
            invoker.AddLevelStartListener(listener);
        }
    }
    public static void AddLevelStartListener(UnityAction handler)
    {
        levelStartListeners.Add(handler);
        foreach (ScreenManager invoker in levelStartInvokers)
        {
            invoker.AddLevelStartListener(handler);
        }
    }
    #endregion

    #region LevelLoadedEvent
    static List<LoadingProgressBar> levelLoadedInvokers = new List<LoadingProgressBar>();
    static List<UnityAction> levelLoadedListeners = new List<UnityAction>();
    public static void AddLevelLoadedInvoker(LoadingProgressBar invoker)
    {
        levelLoadedInvokers.Add(invoker);
        foreach (UnityAction listener in levelStartListeners)
        {
            invoker.AddLevelLoadedListener(listener);
        }
    }
    public static void AddLevelLoadedListener(UnityAction handler)
    {
        levelStartListeners.Add(handler);
        foreach (LoadingProgressBar invoker in levelLoadedInvokers)
        {
            invoker.AddLevelLoadedListener(handler);
        }
    }
    #endregion
}
