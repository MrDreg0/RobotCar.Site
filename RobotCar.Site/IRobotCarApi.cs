using Refit;
namespace RobotCar.Site;

public interface IRobotCarApi
{
  [Get("/{command}")]
  Task SendCommand(string command);
  
  [Post("/motorPower/{motorPower}")]
  Task SetMotorPower(int motorPower);
  
  [Get("/live")]
  Task<HttpResponseMessage> CheckLiveness(CancellationToken cancellationToken = default);
}
