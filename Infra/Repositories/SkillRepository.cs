﻿using Microsoft.EntityFrameworkCore;
using VortiDex.Model;

namespace VortiDex.Infra.Repositories;

public class SkillRepository
{
    private readonly PokeContext _context;

    public SkillRepository(PokeContext context)
    {
        _context = context;
    }

    public Skill CreateRep(Skill skill)
    {
        _context.Skills.Add(skill);
        _context.SaveChanges();

        return (skill);
    }

    public Skill? FindById(int id)
    {
       return _context.Skills.FirstOrDefault(skill => skill.Id == id);
    }

    public ICollection<Skill> GetAllRep()
    {
       return _context
            .Skills
            .Include(skill => skill.Pokemons)
            .ThenInclude(skill => skill.PokeTypes)
            .ToList();
    }

    public Skill UpdateRep(Skill skill)
    {
        _context.Skills.Update(skill);
        _context.SaveChanges();

        return (skill);
    }

    public Skill DeleteRep(Skill skill)
    {
        _context.Skills.Remove(skill);
        _context.SaveChanges();

        return (skill);
    }

    public bool Exists(int id)
    {
        return _context.Skills.Any(skill => skill.Id == id);
    }
}
