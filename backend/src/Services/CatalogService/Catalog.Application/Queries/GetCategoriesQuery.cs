﻿using Catalog.Application.Responses;
using Common.Queries;
using MediatR;

namespace Catalog.Application.Queries;

public class GetCategoriesQuery: PaginationBaseQuery, IRequest<PaginationDto<CategoryDto>>
{
}
