public class QueryStringChannelResolver : DetermineChannelProcessorBase
{
  public override void Process(DetermineChannelProcessorArgs args)
  {
    try
    {
      Assert.ArgumentNotNull((object) args, nameof(args));
      if (Sitecore.Context.Request?.QueryString?.QueryStrings != null &&
      string.IsNullOrWhiteSpace(Sitecore.Context.Request?.QueryString[ConstantsValues.ChannelId]))
      return;
      var channelId = this.GetChannelId();
      if (!Sitecore.Data.ID.IsNullOrEmpty(channelId))
      {
        args.ChannelId = channelId;
      }
    }
  catch (Exception exception)
    {
      Sitecore.Diagnostics.Log.Error(“Error setting custom channel id for traffic types”, exception,
      typeof(QueryStringChannelResolver));
    }
  }
public ID GetChannelId()
{
      var queryString = Sitecore.Context.Request?.QueryString[“ChannelId”];
      ID channelId;
      if (ID.TryParse(queryString, out channelId))
      {
        return channelId;
      }
    return null;
}
}
