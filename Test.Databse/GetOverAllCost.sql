CREATE PROCEDURE [dbo].[GetOverAllCost]
	@Distance int,
	@Stair int,
	@CustType int
AS

DECLARE @distanceThreshold int = 50
DECLARE @stairThreshold int = 5
DECLARE @tempOutPut float 

IF EXISTS(Select 1 from dbo.CustomerVarientCost where Id = @CustType)
 BEGIN
   SELECT @tempOutPut = OverAllCost from dbo.CustomerVarientCost where Id = @CustType
   return @tempOutPut
 END
ELSE
 BEGIN
    IF(@Distance = 0 AND @Stair = 0)
	 BEGIN
		 SELECT @tempOutPut = (dist.OverAllCost + stair.OverAllCost) 
		 FROM DBO.DistanceVarientBaseCost as dist,DBO.StairsVarientBaseCost as stair WHERE dist.MinDist = 0 and stair.MinStair = 0
		  return @tempOutPut
     END
    ELSE
	 BEGIN
	   IF( @Distance <= @distanceThreshold and @Stair <= @stairThreshold)
	     BEGIN
		   SELECT @tempOutPut = (dist.OverAllCost + stair.OverAllCost) 
		   FROM DBO.DistanceVarientBaseCost as dist,DBO.StairsVarientBaseCost as stair WHERE dist.MaxDist <= @Distance and stair.MinStair <= @Stair
		    return @tempOutPut
		 END
      ELSE
	   BEGIN 
	     SELECT @tempOutPut = (dist.OverAllCost + stair.OverAllCost) 
		   FROM DBO.DistanceVarientBaseCost as dist,DBO.StairsVarientBaseCost as stair WHERE dist.MaxDist = @distanceThreshold and stair.MinStair = @stairThreshold
		   Set @tempOutPut = @tempOutPut + ((@Distance - @distanceThreshold)* 0.25) + ((@Stair-@stairThreshold)*2)
		   return @tempOutPut

	   END
	 END
 END
RETURN 0
