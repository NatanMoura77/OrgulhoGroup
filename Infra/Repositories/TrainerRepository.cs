﻿using Microsoft.EntityFrameworkCore;
using VortiDex.Infra.Repositories.Interfaces;
using VortiDex.Model;

namespace VortiDex.Infra.Repositories;

public class TrainerRepository : ITrainerRepository
{
    private readonly PokeContext _context;
    public TrainerRepository(PokeContext context)
    {
        _context = context;
    }

    public Trainer CreateRep(Trainer trainer)
    {
        _context.Trainers.Add(trainer);
        _context.SaveChanges();

        return(trainer);
    }

    public Trainer? FindById(int id)
    {
       return _context
            .Trainers
            .Include(trainer => trainer.Squads)
            .FirstOrDefault(trainer => trainer.Id == id);
       
    }

    public ICollection<Trainer> GetAllRep()
    {
        return _context
            .Trainers
            .Include(trainer => trainer.Squads)
            .ToList();
    }

    public Trainer UpdateRep(Trainer trainer)
    {
        _context.Trainers.Update(trainer);
        _context.SaveChanges();

        return(trainer);
    }

    public Trainer DeleteRep(Trainer trainer)
    {
        _context.Trainers.Remove(trainer);
        _context.SaveChanges();

        return(trainer);
    }
}
