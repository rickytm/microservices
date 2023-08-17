﻿namespace Catalog.Application.Dtos;

public class AttributeGroupedDto
{
    public string Key { get; set; }
    public string Value { get; set; }
    public List<AttributeValueDto>? Values { get; set; }
}