using System;
using Havit.Data.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace MensaGymnazium.IntranetGen3.Entity;

public class IntranetGen3DbContext : Havit.Data.EntityFrameworkCore.DbContext
{
	/// <summary>
	/// Konstruktor.
	/// Pro použití v unit testech, jiné použití nemá.
	/// </summary>
	internal IntranetGen3DbContext()
	{
		// NOOP
	}

	/// <summary>
	/// Konstruktor.
	/// </summary>
	public IntranetGen3DbContext(DbContextOptions options) : base(options)
	{
		// NOOP
	}

	/// <inheritdoc />
	protected override void CustomizeModelCreating(ModelBuilder modelBuilder)
	{
		base.CustomizeModelCreating(modelBuilder);

		modelBuilder.RegisterModelFromAssembly(typeof(MensaGymnazium.IntranetGen3.Model.Common.ApplicationSettings).Assembly);
		modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
	}
}
