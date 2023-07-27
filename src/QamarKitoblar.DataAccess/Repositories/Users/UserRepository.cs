using Dapper;
using QamarKitoblar.DataAccess.Common.Interfaces;
using QamarKitoblar.DataAccess.Interfaces.Users;
using QamarKitoblar.DataAccess.Utils;
using QamarKitoblar.DataAccess.ViewModels.UsersVM;
using QamarKitoblar.Domain.Entities.Users;

namespace QamarKitoblar.DataAccess.Repositories.Users
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public async Task<long> CountAsync()
        {
            try
            {
                await _connection.OpenAsync();
                string query = "Select Count(*) From users";
                var result=await _connection.QuerySingleAsync<long>(query); 
                return result;
            }
            catch 
            {
                return 0;
            }
            finally 
            {
                await _connection.CloseAsync();
            }
        }

        public async Task<int> CreateAsync(User entity)
        {
            try
            {
                await _connection.OpenAsync();
                string query = "INSERT INTO public.users(first_name, last_name, phone_number, phone_number_confirmed, passport_seria_number, " +
                    "is_male, birth_date, country, region, postal_number, password_hash, salt, image_path, last_activity, identity_role                           , " +
                    "created_at, updated_at) " +
                    $"VALUES (@FirstName, @LastName, @PhoneNumber, @PhoneNumberConfirmed, @PassportSeriaNumber, @IsMale, '{entity.BirthDate.Year}-{entity.BirthDate.Month}-{entity.BirthDate.Day}', " +
                    "@Country, @Region, @PostalNumber, @PasswordHash, @Salt, @ImagePath, @LastActivity, " +
                    "@IdentityRole, @CreatedAt, @UpdatedAt);";
                var result = await _connection.ExecuteAsync(query, entity);
                return result;
            }
            catch
            {
                return 0;
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public async Task<int> DeleteAsync(long id)
        {
            try
            {
                await _connection.OpenAsync();
                string query = "DELETE FROM users WHERE id=@Id;";
                var result=await _connection.ExecuteAsync(query, new { Id=id });
                return result;
            }
            catch
            {
                return 0;
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public async Task<IList<UserViewModel>> GetAllAsync(PaginationParams @params)
        {
            try
            {
                await _connection.OpenAsync();
                string query = "SELECT * FROM public.users Order By id Desc " +
                    $"Offset {@params.GetSkipCount()} Limit {@params.PageSize}";
                var result=(await _connection.QueryAsync<UserViewModel>(query)).ToList();
                return result;
            }
            catch
            {
                return new List<UserViewModel>();
            }
            finally
            {
                await _connection.CloseAsync() ;
            }
        }

        public async Task<UserViewModel?> GetByIdAsync(long id)
        {
            try
            {
                await _connection.OpenAsync();
                string query = "Select * From users where id=@Id";
                var result=await _connection.QuerySingleAsync<UserViewModel>(query, new {Id=id});
                return result;
            }
            catch
            {
                return null;
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public async Task<User?> GetByIdCheckUser(long id)
        {
            try
            {
                await _connection.OpenAsync();
                string query = "Select * From users where id=@Id";
                var result = await _connection.QuerySingleAsync<User>(query, new { Id = id });
                return result;
            }
            catch
            {
                return null;
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public async Task<User?> GetByPhoneAsync(string phone)
        {
            try
            {
                await _connection.OpenAsync();
                string query = "Select * From users where phone_number like @PhoneNumber";
                var result=await _connection.QuerySingleAsync<User>(query, new {PhoneNumber=phone});
                return result;
            }
            catch
            {
                return null;
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public async Task<(long ItemsCount, IList<UserViewModel>)> SearchAsync(string search, PaginationParams @params)
        {
            try
            {
                await _connection.OpenAsync();
                string query = $"Select * From users Where first_name ilike @search Order By first_name " +
                    $"Offset {@params.GetSkipCount()} Limit {@params.PageSize}";
                var result = (await _connection.QueryAsync<UserViewModel>(query, new {search = "%" + search + "%"})).ToList();
                long count= result.LongCount();
                return (count, result);
            }
            catch
            {
                return (0,new List<UserViewModel>());
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public async Task<int> UpdateAsync(long id, User entity)
        {
            try
            {
                await _connection.OpenAsync();
                string query = "UPDATE public.users SET first_name=@FirstName, last_name=@LastName, phone_number=@PhoneNumber, " +
                    "phone_number_confirmed=@PhoneNumberConfirmed, passport_seria_number=@PassportSeriaNumber, is_male=@IsMale, " +
                    $"birth_date='{entity.BirthDate.Year}-{entity.BirthDate.Month}-{entity.BirthDate.Day}', country=@Country, region=@Region, postal_number=@PostalNumber, password_hash=@PasswordHash, " +
                    "salt=@Salt, image_path=@ImagePath, last_activity=@LastActivity, identity_role=@IdentityRole, created_at=@CreatedAt, " +
                    $"updated_at=@UpdatedAt WHERE id={id};";
                var result = await _connection.ExecuteAsync(query, entity);
                return result;
            }
            catch
            {
                return 0;
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        
    }
}
