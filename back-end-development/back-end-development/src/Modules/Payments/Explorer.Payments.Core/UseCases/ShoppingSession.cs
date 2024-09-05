using Explorer.Payments.API.Internal;
using Explorer.Payments.API.Public.ShoppingCart;
using Explorer.Payments.Core.Domain.RepositoryInterfaces;
using Explorer.Payments.Core.Domain.ShoppingSessionEventSourcing;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Payments.Core.UseCases
{
    public class ShoppingSession : IInternalShoppingSession, IShoppingSession
    {
        protected readonly IShoppingSessionRepository _shoppingSessionRepository;
  

        public ShoppingSession(IShoppingSessionRepository shoppingSessionRepository)
        {
            _shoppingSessionRepository= shoppingSessionRepository;
        }

        public void OpenShoppingSession(long id)
        {
            ShoppingSessionEvent shoppingEvent = _shoppingSessionRepository.GetByAggregateId(id);
            if(shoppingEvent != null) 
            {
                return; 
                if (shoppingEvent.TimeStamp.AddMinutes(30) >= DateTime.UtcNow)
                {

                }
            }

            try
            {
                ShoppingSessionEvent shoppingSessionEvent = new ShoppingSessionEvent(id, DateTime.UtcNow,true);
                shoppingSessionEvent.CreateSession(id);
                _shoppingSessionRepository.Create(shoppingSessionEvent);

            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        public void AddTourToShoppingCartEvent(long id)
        {
            ShoppingSessionEvent shoppingEvent = _shoppingSessionRepository.GetByAggregateId(id);
            try
            {
                shoppingEvent.AddTour(id);
                _shoppingSessionRepository.UpdateShoppingSessionEvent(shoppingEvent);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void RemoveTourShoppingCartEvent(long id)
        {
            ShoppingSessionEvent shoppingEvent = _shoppingSessionRepository.GetByAggregateId(id);
            try
            {
                shoppingEvent.RemoveTour(id);
                _shoppingSessionRepository.UpdateShoppingSessionEvent(shoppingEvent);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void CloseShoppingEvent(long id)
        {
            ShoppingSessionEvent shoppingEvent = _shoppingSessionRepository.GetByAggregateId(id);
            shoppingEvent.isActive= false;
            try
            {
                shoppingEvent.CloseSession(id);
                _shoppingSessionRepository.UpdateShoppingSessionEvent(shoppingEvent);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void AddTourBundleToShoppingCartEvent(long id)
        {
            ShoppingSessionEvent shoppingEvent = _shoppingSessionRepository.GetByAggregateId(id);
            try
            {
                shoppingEvent.AddTourBundle(id);
                _shoppingSessionRepository.UpdateShoppingSessionEvent(shoppingEvent);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void AddCouponToShoppingCartEvent(long id)
        {
            ShoppingSessionEvent shoppingEvent = _shoppingSessionRepository.GetByAggregateId(id);
            try
            {
                shoppingEvent.AddCoupon(id);
                _shoppingSessionRepository.UpdateShoppingSessionEvent(shoppingEvent);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void RemoveTourBundleShoppingCartEvent(long id)
        {
            ShoppingSessionEvent shoppingEvent = _shoppingSessionRepository.GetByAggregateId(id);
            try
            {
                shoppingEvent.RemoveTourBundle(id);
                _shoppingSessionRepository.UpdateShoppingSessionEvent(shoppingEvent);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public bool CheckActiveShoppingSession(long id)
        {
            ShoppingSessionEvent shoppingEvent = _shoppingSessionRepository.GetByAggregateId(id);
            if (shoppingEvent != null)
            {
                if (shoppingEvent.TimeStamp.AddMinutes(30) >= DateTime.UtcNow)
                {
                    return true;
                }
                else
                {
                    shoppingEvent.isActive = false;
                    try
                    {
                        shoppingEvent.CloseSession(id);
                        _shoppingSessionRepository.UpdateShoppingSessionEvent(shoppingEvent);

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

    }
}
